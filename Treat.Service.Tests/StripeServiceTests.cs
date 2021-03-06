﻿using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Treat.Service.Tests
{
    [TestClass]
    public class StripeServiceTests
    {
        private readonly IPaymentService _paymentService;

        public StripeServiceTests()
        {
            var settings = new Settings();
            _paymentService = new StripeService(settings);
        }

        [TestMethod]
        public void Should_create_customer()
        {
            var customerId = _paymentService.CreateCustomer("victor@stodell.se", "Victor Stodell", "348nifjn487w3");
            Trace.WriteLine("Created customer with id " + customerId);
            // Created customer with id 68146085
        }

        [TestMethod]
        public void Should_create_payment_method()
        {
            var token = _paymentService.CreatePaymentMethod("68146085", "fake-valid-visa-nonce");
            Trace.WriteLine("Created payment method with token " + token);
            // Created payment method with token 9ht792
        }

        [TestMethod]
        public void Should_create_payment()
        {
            var id = _paymentService.CreatePayment("68146085", "9ht792", 75);
            Trace.WriteLine("Created payment with id " + id);
            // Created payment with Id 6tdjd8
        }
    }
}