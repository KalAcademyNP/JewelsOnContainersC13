using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebMvc.Infrastructure;
using WebMvc.Models;
using WebMvc.Models.CartModels;

namespace WebMvc.Services
{
    public class CartService : ICartService
    {
        private readonly string _baseUrl;
        private readonly IConfiguration _config;
        private readonly IHttpClient _apiClient;
        private readonly IHttpContextAccessor _httpContextAccesor;
        public CartService(IConfiguration config, IHttpClient client,
            IHttpContextAccessor httpContextAccesor)
        {
            _config = config;
            _apiClient = client;
            _httpContextAccesor = httpContextAccesor;
            _baseUrl = $"{config["CartUrl"]}/api/cart";
        }

        private async Task<string> GetUserTokenAsync()
        {
            var context = _httpContextAccesor.HttpContext;
            return await context.GetTokenAsync("access_token");
        }
        public async Task AddItemToCart(ApplicationUser user, CartItem product)
        {
            //Get the users cart
            var cart = await GetCart(user);
            //if the item exists in the cart. if yes, increase quantity. if no, add item
            var basketItem =
                cart.Items.Where(p => p.ProductId == product.ProductId).FirstOrDefault();
            if (basketItem == null)
            {
                cart.Items.Add(product);
            }
            else
            {
                basketItem.Quantity++;
            }
            //update cart
            await UpdateCart(cart);
        }

        public async Task ClearCart(ApplicationUser user)
        {
            var token = await GetUserTokenAsync();
            var cleanBasketUri = APIPaths.Basket.CleanBasket(_baseUrl, user.Email);
            await _apiClient.DeleteAsync(cleanBasketUri, token);
        }

        public async Task<Cart> GetCart(ApplicationUser user)
        {
            var token = await GetUserTokenAsync();
            var getBasketUri = APIPaths.Basket.GetBasket(_baseUrl, user.Email);
            var dataString = await _apiClient.GetStringAsync(getBasketUri, token);
            var response = JsonConvert.DeserializeObject<Cart>(dataString) ??
                new Cart
                {
                    BuyerId = user.Email
                };
            return response;
        }

        public async Task<Cart> SetQuantities(ApplicationUser user, 
            Dictionary<string, int> quantities)
        {
            //Get cart
            var basket = await GetCart(user);
            basket.Items.ForEach(x =>
            {
                if (quantities.TryGetValue(x.Id, out var quantity))
                {
                    x.Quantity = quantity;
                }
            });
            return basket;
        }

        //public Order MapCartToOrder(Cart cart)
        //{
        //    var order = new Order();
        //    order.OrderTotal = 0;

        //    cart.Items.ForEach(x =>
        //    {
        //        order.OrderItems.Add(new OrderItem()
        //        {
        //            ProductId = int.Parse(x.ProductId),

        //            PictureUrl = x.PictureUrl,
        //            ProductName = x.ProductName,
        //            Units = x.Quantity,
        //            UnitPrice = x.UnitPrice
        //        });
        //        order.OrderTotal += (x.Quantity * x.UnitPrice);
        //    });

        //    return order;
        //}

        public async Task<Cart> UpdateCart(Cart cart)
        {
            var token = await GetUserTokenAsync();
            var updateBasketUri = APIPaths.Basket.UpdateBasket(_baseUrl);
            var response = await _apiClient.PostAsync(updateBasketUri, cart, token);

            response.EnsureSuccessStatusCode();

            return cart;
        }
    }
}
