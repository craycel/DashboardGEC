var testWebStaff = (function () {

    function setCookie(valueSet) {
        
        // Set a cookie
        $.cookie("name", valueSet);
        
        return true;
    }

    function getCookie(nameCookie) {
        // Read the cookie
        var cookieValue = $.cookie(nameCookie);

        return cookieValue;
    }

    function testCode() {
        console.log("Tested");
    }

    return {
        setCookie: setCookie,
        getCookie: getCookie,
        testCode: testCode
    };
})();