var cleave = new Cleave('#cardNumber', {
    creditCard: true,
    delimiter: " ",
    onCreditCardTypeChanged: function (type) {
        
    }
});

var cleaveExpiry = new Cleave('#expiry', {
    date: true,
    datePattern: ["m", "y"]
});

var cleaveCVV = new Cleave('#cvv', {
    blocks: [3]
});