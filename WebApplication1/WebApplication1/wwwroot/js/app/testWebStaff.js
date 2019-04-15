var testWebStaff = (function () {
    function setCookie(valueSet) {
        
        // Set a cookie
        _setCookie("name", valueSet ,10)
    }

   
    function getCookie(nameCookie) {
        // Read the cookie
        var cookieValue = _getCookie(nameCookie);//
        return cookieValue;
    }      

    //jQuery
    /*
    $.cookie("test", 1, {
        expires: 10,          

        path: '/',         

        domain: 'jquery.com', 

        secure: true         
    });*/

    function testCode() {
        console.log("Tested");
    }

    function setLocalStorage(name,valueS) {
        localStorage.setItem(name, valueS);
    }

    function getLocalStorage(name) {
        localStorage.getItem(name);
    }

    function setSessionStorage(name, valueS) {
        sessionStorage.setItem(name, valueS);
    }

    function getSessionStorage(name) {
        return sessionStorage.getItem(name);
    }



    return {
        setCookie: setCookie,
        getCookie: getCookie,
        testCode: testCode,
        setLS: setLocalStorage,
        getLS: getLocalStorage,
        setSS: setSessionStorage,
        getSS: getSessionStorage
        
    };
})();