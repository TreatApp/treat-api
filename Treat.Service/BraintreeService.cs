using System;
using Braintree;
using Microsoft.WindowsAzure;
using RestSharp.Extensions;
using Treat.Model;
using Environment = Braintree.Environment;

namespace Treat.Service
{
    public class BraintreeService : IPaymentService
    {
        private readonly BraintreeGateway _gateway ;

        public BraintreeService(ISettings settings)
        {
            _gateway = new BraintreeGateway
            {
                Environment = settings.BraintreeEnvironment == "PRODUCTION" ? Environment.PRODUCTION : Environment.SANDBOX,
                MerchantId = settings.BraintreeMerchantId,
                PublicKey = settings.BraintreePublicKey,
                PrivateKey = settings.BraintreePrivateKey
            };
        }

        public string GetClientToken(string customerId = null)
        {
            var request = new ClientTokenRequest
            {
                CustomerId = customerId
            };
            return _gateway.ClientToken.generate(request);
        }

        public string CreateCustomer(string firstName, string lastName)
        {
            var request = new CustomerRequest
            {
                FirstName = firstName,
                LastName = lastName
            };
            var result = _gateway.Customer.Create(request);
            var success = result.IsSuccess();
            var customer = result.Target;
            return customer.Id;
        }

        public string CreatePaymentMethod(string customerId, string nonce)
        {
            var request = new PaymentMethodRequest
            {
                CustomerId = customerId,
                PaymentMethodNonce = nonce
            };
            var result = _gateway.PaymentMethod.Create(request);
            var success = result.IsSuccess();
            var paymentMethod = result.Target;
            return paymentMethod.Token;
        }

        public string CreatePayment(string customerId, string token, decimal amount)
        {
            var request = new TransactionRequest
            {
                CustomerId = customerId,
                PaymentMethodToken = token,
                Amount = amount
            };
            var result = _gateway.Transaction.Sale(request);
            var success = result.IsSuccess();
            var transaction = result.Target;
            return transaction.Id;
        }
    }
}