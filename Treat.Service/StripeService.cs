using System;
using Stripe;
using Treat.Model;

namespace Treat.Service
{
    public class StripeService : IPaymentService
    {
        public StripeService(ISettings settings)
        {
            StripeConfiguration.SetApiKey(settings.StripeApiKey);
        }

        public string GetClientToken(string customerId = null)
        {
            return null;
        }

        public string CreateCustomer(string email, string description, string token)
        {
            var createOptions = new StripeCustomerCreateOptions
            {
                Email = email,
                Description = description,
                SourceToken = token
            };
            var customerService = new StripeCustomerService();
            var customer = customerService.Create(createOptions);
            return customer.Id;
        }

        public string CreatePaymentMethod(string customerId, string token)
        {
            var createOptions = new StripeCardCreateOptions
            {
                SourceToken = token
            };
            var cardService = new StripeCardService();
            var card = cardService.Create(customerId, createOptions);
            return card.Id;
        }

        public string CreatePayment(string customerId, string token, decimal amount)
        {
            var createOptions = new StripeChargeCreateOptions
            {
                Amount = Convert.ToInt32(amount),
                Currency = "SEK",
                SourceTokenOrExistingSourceId = token,
                CustomerId = customerId,
                Capture = true
            };
            var chargeService = new StripeChargeService();
            var charge = chargeService.Create(createOptions);
            return charge.Id;
        }

        public void CancelPayment(string transactionId)
        {
            throw new NotImplementedException();
        }

        public void RefundPayment(string transactionId)
        {
            throw new NotImplementedException();
        }
    }
}