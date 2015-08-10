function authorizationService($resource) {
    var sessionValue = null;
    var authenticatedCardNumber = null;

    var authorization = $resource("/authorization", [], {
        "authenticateCardNumber": { url: "/authorization/AuthenticateCardNumber", isArray: false, method: "POST" },
        "authorizePin": { url: "/authorization/authorizePin", isArray: false, method: "POST" },
        "closeSession": { url: "/authorization/closeSession", isArray: false, method: "POST" },
    });

    this.authenticateCardNumber = function (cardNumber) {
         return authorization.authenticateCardNumber({ CardNumber: cardNumber }).$promise;
    }

    this.authorizePin = function (pin) {
        return authorization.authorizePin({ CardNumber: authenticatedCardNumber, Pin: pin }).$promise;
    };

    this.setCardNumber = function (cardNumber) {
        authenticatedCardNumber = cardNumber;
    }

    this.getCardNumber = function () {
        return authenticatedCardNumber;
    }

    this.setSessionValue = function (session, isAthorization) {
        if (session == null && !isAthorization) {
            this.clearSession();
        }

        sessionValue = session;
    }

    this.getSessionValue = function (session) {
        return sessionValue;
    }

    this.isSession = function () {
        return sessionValue != null ? true : false;
    }

    this.clearSession = function () {
        sessionValue = null;
        authenticatedCardNumber = null;
    }
}