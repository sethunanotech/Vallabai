
var alpha = "[A-Za-z ]";
var numeric = "[0-9]";
var numericwithhash = "[A-Za-z0-9#]";
var numericwithslash = "[A-Za-z0-9/ ]";

var alphanumeric = "[A-Za-z0-9]";
var alphanumericwithspecialchar = "[A-Za-z0-9+. ]";

var numericwithdot = "[0-9.]";

function onKeyValidate(e, charVal) {
    
    var keynum;
    var keyChars = /[\x00\x08]/;
    var validChars = new RegExp(charVal);
    if (window.event) {
        keynum = e.keyCode;
    }
    else if (e.which) {
        keynum = e.which;
    }
    var keychar = String.fromCharCode(keynum);
    if (!validChars.test(keychar) && !keyChars.test(keychar)) {
        return false
    } else {
        return keychar;
    }
}
