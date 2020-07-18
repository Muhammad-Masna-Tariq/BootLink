$(document).on("mouseenter", ".highlight", function () {
  //Checking if border property already exists
  /*if ($(this).css("border-width") != undefined) {
    tempBordersize = $(this).css("border-size");
  }
  if ($(this).css("border-color") != undefined) {
    tempBorderColor = $(this).css("border-color");
  }
  if ($(this).css("border-style") != undefined) {
    tempBorderstyle = $(this).css("border-style");
  }*/
  /*var attr = $(this).attr('border');

    // For some browsers, `attr` is undefined; for others,
    // `attr` is false.  Check for both.
    if (typeof attr !== typeof undefined && attr !== false) {
        tempBorder
    }*/
  $(this).css("border", "5px solid #eb2d3a");
  // $(this).css("background-color", "#1b1c20");
  // $(this).css("color", "#ffffff");
});
$(document).on("mouseleave", ".highlight", function () {
  $(this).css("border", "");
});
$(document).on("dblclick", ".highlight", function () {
  $(this).css("border", "2px solid #eb2d3a");
  $(this).removeClass("highlight");
  $(this).addClass("clickedItem");
});
$(document).on("dblclick", ".clickedItem", function () {
  $(this).css("border", "");
  $(this).removeClass("clickedItem");
  $(this).addClass("highlight");
});

//Add a medium listener to detect text edition
jQuery(".editable").change(function () {
  var result = $.fn.getCleanCode();

  //calling async obj
  (async function () {
    await CefSharp.BindObjectAsync("getHTMLfromjs");
    //The default is to camel case method names (the first letter of the method name is changed to lowercase)
    getHTMLfromjs.updateChange();
    getHTMLfromjs.updateHTMLBox(result);
  })();
});

//Starting Update
$(document).ready(function () {
  var result = $.fn.getCleanCode();

  //calling async obj
  (async function () {
    await CefSharp.BindObjectAsync("getHTMLfromjs");

    //The default is to camel case method names (the first letter of the method name is changed to lowercase)
    getHTMLfromjs.updateChange("false");
    getHTMLfromjs.updateHTMLBox(result);
  })();
});

function cssStringFunc(myvar) {
  var cssString = myvar;
  var splitString = cssString.split(" ");

  splitString[0] = "#" + splitString[0];
  splitString[1] = splitString[1].substring(0, splitString[1].length - 1);
  $(splitString[0]).css(splitString[1], splitString[2]);
}

function cssNumFunc(myvar) {
  var cssString = myvar;
  var splitString = cssString.split(" ");

  splitString[0] = "#" + splitString[0];
  splitString[1] = splitString[1].substring(0, splitString[1].length - 1);
  splitString[2] = splitString[2] + "px";
  $(splitString[0]).css(splitString[1], splitString[2]);
}