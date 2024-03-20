function button(){
    //alert("button clicked");
    var x = document.getElementById("hide");
    if (x.style.visibility == "hidden") {
      document.getElementById("hidebutton").innerHTML = "Hide";
      x.style.visibility = "visible";
    } else {
      x.style.visibility = "hidden";
      document.getElementById("hidebutton").innerHTML = "Show";
    }

    var carousel = document.getElementById("myCarousel");
    if (carousel.style.visibility === "hidden") {
      carousel.style.visibility = "visible";
    } else {
      carousel.style.visibility = "hidden";
    }
    
}
function showCalculateForm(){
    var ele = document.getElementById("form");
    if(ele.style.visibility == "hidden")
        ele.style.visibility = "visible";
}
function calculate(){

  var num1 = document.getElementById("number1").value;
  var num2 = document.getElementById("number2").value;

  var sum = parseFloat(num1) + parseFloat(num2);

  document.getElementById("result").innerHTML = "Result: " + sum;
}