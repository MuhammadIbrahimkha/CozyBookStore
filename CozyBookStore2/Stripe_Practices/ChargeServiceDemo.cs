//using Microsoft.AspNetCore.Mvc;
//using Stripe;

//namespace CozyBookStore2.Stripe_Practices
//{
//    public class ChargeServiceDemo : Controller
//    {
//        public IActionResult Index()
//        {
//            StripeConfiguration.ApiKey = "My-Key";

//            // ChargeService class.
//            // This class provides methods for creating, retrieving, updating, and capturing charges.

//            var chargeService = new ChargeService();

//            var charge = chargeService.Create(new ChargeCreateOptions
//            {
//                Amount = 1000,  // Amount in cents
//                Currency = "usd",
//                Source = "tok_visa", // replace with a valid token.

//            });



//            // Customer Service class. 
//            // This class provides methods for creating, retrieving, updating, and deleting customers.


//            var customerService = new CustomerService();
//            var customer = customerService.Create(new CustomerCreateOptions
//            {
//                Email = "customer@example.com",
//                Name = "Muhammad Ibrahim"
//            });


//            // TokenService: This class provides methods for creating tokens, which represent sensitive payment information in a secure way.

//            var tokenService = new TokenService();

//            var token = tokenService.Create(new TokenCreateOptions
//            {
//                Card = new TokenCardOptions
//                {
//                    Number = "3242323423423",
//                    ExpMonth = "12",
//                    ExpYear = "26",
//                    Cvc = "321"
//                }
//            });


//            // PaymentIntentService: This class provides methods for creating, retrieving, updating, confirming, and canceling PaymentIntents, which are used to manage the payment flow.


//            var paymentIntentService = new PaymentIntentService();
//            var paymentIntent = paymentIntentService.Create(new PaymentIntentCreateOptions
//            {
//                Amount = 1000,
//                Currency = "usd",
//                AutomaticPaymentMethods = new PaymentIntentAutomaticPaymentMethodsOptions
//                {
//                    Enabled = true
//                }
//            });




//            // SubscriptionService: This class provides methods for creating, retrieving, updating, and canceling subscriptions.


//            var subsriptionService = new SubscriptionService();

//            var subscription = subsriptionService.Create(new SubscriptionCreateOptions
//            {
//                Customer = "cus_xxxxxxxxxxxxxxxxx",
//                Items = new List<SubscriptionItemOptions>
//                {
//                    new SubscriptionItemOptions
//                    {
//                        Price = "price_xxxxxxxxxxxxxxx"
//                    }
//                }
//            });




//            return View();
//        }
//    }
//}
