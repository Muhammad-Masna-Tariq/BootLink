$(document).on("mouseenter", ".highlight", function() {
  $(this).css("border", "5px solid #eb2d3a");
  // $(this).css("background-color", "#1b1c20");
  // $(this).css("color", "#ffffff");
});
$(document).on("mouseleave", ".highlight", function() {
  $(this).css("border", "");
  $(this).css("background-color", "");
  $(this).css("color", "");
});
$(document).on("click", ".highlight", function() {
  $(this).css("border", "2px solid #eb2d3a");
  $(this).css("background-color", "#f7ffcb");
  $(this).removeClass("highlight");
  $(this).addClass("clickedItem");
});
$(document).on("click", ".clickedItem", function() {
  $(this).css("border", "");
  $(this).css("background-color", "");
  $(this).removeClass("clickedItem");
  $(this).addClass("highlight");
});

//Add a medium listener to detect text edition
jQuery(".editable").change(function() {
  var result = $.fn.getCleanCode();

  //calling async obj
  (async function() {
    await CefSharp.BindObjectAsync("getHTMLfromjs");
    //The default is to camel case method names (the first letter of the method name is changed to lowercase)
    getHTMLfromjs.updateChange();
    getHTMLfromjs.updateHTMLBox(result);
  })();
});

//Starting Update
$(document).ready(function() {
  var result = $.fn.getCleanCode();

  //calling async obj
  (async function() {
    await CefSharp.BindObjectAsync("getHTMLfromjs");

    //The default is to camel case method names (the first letter of the method name is changed to lowercase)
    getHTMLfromjs.updateChange("false");
    getHTMLfromjs.updateHTMLBox(result);
  })();
});
