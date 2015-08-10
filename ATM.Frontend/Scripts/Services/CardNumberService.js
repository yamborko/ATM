function cardNumberService($resource) {

    var cardNumber = $resource("/cardNumber", [], {
        "checkAccountBalance": { url: "/cardNumber/CheckCardNumberBalance", isArray: false, method: "POST" },
        "withdrawCash": { url: "/cardNumber/WithdrawCash", isArray: false, method: "POST" },
    });

    this.checkAccountBalance = function (session) {
        console.log(session);
        return cardNumber.checkAccountBalance({ SessionValue: session }).$promise;
    }

    this.withdrawCash = function (session, amount) {
        return cardNumber.withdrawCash({ SessionValue: session, Amount: amount }).$promise;
    };
}