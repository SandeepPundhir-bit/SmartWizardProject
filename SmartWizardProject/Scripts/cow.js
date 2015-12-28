
 
    function GetCurrentDate() {
        var date =  new Date();
        return date.getDate() + "/" + (date.getMonth() + 1) + "/" + date.getFullYear();
         
    }


    function GetInputEqualToFive(input) {
        return parseInt(input,10) === 5 ? true : false;
    }
 

    function yell(n) {
        return n > 0 ? yell(n - 1) + n: "hello";
    }


    function Ninja() {
        this.swung = false;
        this.swungNumber = 1;
    }

    Ninja.prototype.SwingSword = function () {
        this.swungNumber = 2;
        this.swung = true;
        return this.swungNumber;
    }

   

