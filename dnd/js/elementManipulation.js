function selectAllElements() {
  $("#right-copy")
    .find("*")
    .each(function () {
      if ($(this).hasClass("highlight")) {
        $(this).css("border", "2px solid #eb2d3a");
        $(this).removeClass("highlight");
        $(this).addClass("clickedItem");
      }

    });
}

function deleteAllElements() {
  $("#right-copy")
    .find(".clickedItem")
    .each(function () {
      $(this).remove();
    });

  setTimeout(function () {
    // Do something after 1 second
    // jQuery
    var result = $.fn.getCleanCode();

    //calling async obj
    (async function () {
      await CefSharp.BindObjectAsync("getHTMLfromjs");

      //The default is to camel case method names (the first letter of the method name is changed to lowercase)
      getHTMLfromjs.updateChange("false");
      getHTMLfromjs.updateHTMLBox(result);
    })();
  }, 600);
}

function copyAllElements() {
  var copyitem = "";
  var getallElements = "";

  //getting all elements
  $("#right-copy")
    .find(".clickedItem")
    .each(function () {
      var tempElement = $(this);
      $(tempElement).css("border", "");
      $(tempElement).removeClass("clickedItem");
      $(tempElement).addClass("highlight");
      copyitem = copyitem + "\n" + $(tempElement).prop("outerHTML");
      $(tempElement).css("border", "2px solid #eb2d3a");
      $(tempElement).addClass("clickedItem");
    });

  //removing all styling
  /*$("#right-copy")
  .find(".clickedItem")
  .each(function () {
    var tempElement = $(this);
    $(tempElement).css("border", "");
    $(tempElement).removeClass("clickedItem");
    $(tempElement)
      .find(".editable")
      .each(function () {
        $(this).removeClass("editable");
        $(this).removeClass("medium-editor-element");

        //Remove attributes
        $(this).removeAttr("contenteditable");
        $(this).removeAttr("spellcheck");
        $(this).removeAttr("data-medium-editor-element");
        $(this).removeAttr("role");
        $(this).removeAttr("aria-multiline");
        $(this).removeAttr("data-medium-editor-editor-index");
        $(this).removeAttr("medium-editor-index");
        $(this).removeAttr("data-placeholder");
        $(this).removeAttr("data-medium-focused");
      });
    var lengths = this.id.length;
    if (lengths > 0) {
      var idcheck = $(this)
        .attr("id")
        .match(/((single-([A-z]+))(-?)(\d)*)|([A-z0-9]){6}/);
      if (!idcheck) {
        var randnum = "single-item" + idnum;
        $(this).attr("id", randnum);
      }
    } else {
      var randnum = "single-item" + idnum;
      $(this).attr("id", randnum);
    }

    //Remove class is class="" <--- empty
    if (!$(this).attr("class")) {
      $(this).removeAttr("class");
    }
    //Remove class is style="" <--- empty
    if (!$(this).attr("style")) {
      $(this).removeAttr("style");
    }

    copyitem = copyitem + "\n" + $(tempElement).prop("outerHTML");
  });*/
  //using tidy.js for html5 formatting
  options = {
    indent: "auto",
    "indent-spaces": 2,
    wrap: 80,
    markup: true,
    "output-xml": false,
    "numeric-entities": true,
    "quote-marks": true,
    "quote-nbsp": false,
    "show-body-only": true,
    "quote-ampersand": false,
    "break-before-br": true,
    "uppercase-tags": false,
    "uppercase-attributes": false,
    "drop-font-tags": true,
    "tidy-mark": false,
  };
  var result = tidy_html5(copyitem, options);
  console.log("COPY RESULT IS");
  console.log(result);
  console.log("==============================");
  copyToClipboard(result);
}

function pasteAllElements(clipboardHTML) {
  //var editedHTML = $.parseHTML(myvar);
  var editedHTML = clipboardHTML;

  $("#pastehtml").html(editedHTML);
  /*$("#pastehtml")
    .find("*")
    .each(function () {
      if ($(this).attr("id") == undefined) {
        $(this).attr("id", "single-item-" + idnum);
        idnum++;
      } else if ($(this).attr("id").trim() == "") {
        $(this).attr("id", "single-item-" + idnum);
        idnum++;
      }
      //For CurrentElementText
      var currentElementText = $(this).clone().children().remove().end().text();

      var currentTagName = $(this).prop("tagName").toLowerCase();
      //some code here
      //for divs
      if (currentTagName == "div") {
        //Checking if div contains any element if yes then add to drakecontainer to let it add more items
        if ($(this).children().length > 0) {
          $(this).addClass("drakecontainer");
          drake.containers.push(document.getElementById($(this).attr("id")));
        } else if ($(this).attr("class").length > 0) {
          var colclasscheck = $(this)
            .attr("class")
            .match(
              /(col-(((md)|(xs)|(sm)|(lg)|(xl))-)?([1-9]))|(row)|(container)|(container-fluid)|(drakecontainer)/
            );
          if (colclasscheck != null) {
            $(this).addClass("drakecontainer");
            drake.containers.push(document.getElementById($(this).attr("id")));
          }
        }
      }
      //for inputs
      else if (currentTagName == "input") {
        //check if it has class highlight
        if (!$(this).hasClass("highlight")) {
          $(this).addClass("highlight");
        }
      }

      //for ul/ol skip the li
      else if (
        currentTagName == "ul" ||
        currentTagName == "ol" ||
        currentTagName == "li"
      ) {
        //check if li
        if (currentTagName == "li") {
          //do nothing
        }
        //it is ol/ul
        else {
          //check if it has class highlight
          if (!$(this).hasClass("highlight")) {
            $(this).addClass("highlight");
          }

          //check if it has class editable
          if (!$(this).hasClass("editable")) {
            $(this).addClass("editable");
          }
        }
      }
      //for text such as p h1-6 buttons etc
      //Check for text of current element not its children/decendent
      else if (currentElementText.trim() != "") {
        if (!$(this).hasClass("highlight")) {
          $(this).addClass("highlight");
        }
        if (!$(this).hasClass("editable")) {
          $(this).addClass("editable");
        }
      }

      //for submit kind of buttons
      else if (currentTagName == "button") {
        if (!$(this).hasClass("highlight")) {
          $(this).addClass("highlight");
        }
        if (!$(this).hasClass("editable")) {
          $(this).addClass("editable");
        }
      }

      //for img/video/audio
      else if (
        currentTagName == "img" ||
        currentTagName == "video" ||
        currentTagName == "audio"
      ) {
        //check if it has class highlight
        if (!$(this).hasClass("highlight")) {
          $(this).addClass("highlight");
        }
      }
    });
  //Medium Editor
  var elements = document.querySelectorAll(".editable"),
    editor = new MediumEditor(elements);
  editor.unsubscribe("editableInput", function (event, editable) {});
  editor.subscribe("editableInput", function (event, editable) {
    // Do some work
    var result = $.fn.getCleanCode();

    //calling async obj
    (async function () {
      await CefSharp.BindObjectAsync("getHTMLfromjs");

      //The default is to camel case method names (the first letter of the method name is changed to lowercase)
      getHTMLfromjs.updateChange("false");

      getHTMLfromjs.updateHTMLBox(result);
    })();
  });*/

  var pastehtml = $("#pastehtml").html();
  console.log("PASTE HTML HERE");
  console.log(pastehtml);
  console.log("=======================");
  $("#right-copy").append(pastehtml);
  $("#pastehtml").html("");

  setTimeout(function () {
    // Do something after 1 second
    // jQuery
    var result = $.fn.getCleanCode();

    //calling async obj
    (async function () {
      await CefSharp.BindObjectAsync("getHTMLfromjs");

      //The default is to camel case method names (the first letter of the method name is changed to lowercase)
      getHTMLfromjs.updateChange("false");
      getHTMLfromjs.updateHTMLBox(result);
    })();
  }, 600);
  /*var itemtype = "";
  var addeditable = false;
  var addtags = false;
  var adddivs = false;
  var adddrakecontainer = false;

  $("#pastehtml > *").filter(function () {
    if ($(this).attr("class") || $(this).attr("id")) {
      //match single-item-(number) or editable or drakecontainer class
      var classcheck = $(this)
        .attr("class")
        .match(/((single-item-)(\d)+)|(editable)|(drakecontainer)|(highlight)/);
      if (!classcheck) {
        addtags = true;
      }

      //match single-item-(number) id
      var idcheck = $(this)
        .attr("id")
        .match(/((single-item-)(\d)+)/);
      if (!idcheck) {
        addtags = true;
      }
    } else {
      addtags = true;
    }

    //check if needed to add tags
    if (addtags) {
      var tagname = $(this).prop("tagName").toLowerCase();
      if (tagname == "div") {
        var randnum = randomId();
        $(this).attr("id", randnum);

        //checking if drakecontainer is needed
        var colclasscheck = $(this)
          .attr("class")
          .match(/(col-([1-9]))|(row)|(container)|(container-fluid)/);
        if (colclasscheck) {
          $(this).addClass("drakecontainer");
          drake.containers.push(document.getElementById(randnum));
        }

        var highlightclasscheck = $(this)
          .attr("class")
          .match(/(highlight)/);
        if (!highlightclasscheck) {
          $(this).addClass("highlight");
        }
      } else {
        adddivs = true;
      }

      var currentHTML = $(this);
      $(currentHTML).each(function () {
        var hasanyText = $(this).text().trim().length;
        if (hasanyText != 0) {
          $(this).addClass("editable");
          //Medium Editor
          var elements = document.querySelectorAll(".editable"),
            editor = new MediumEditor(elements);
          editor.unsubscribe("editableInput", function (event, editable) {});
          editor.subscribe("editableInput", function (event, editable) {
            // Do some work
            var result = $.fn.getCleanCode();

            //calling async obj
            (async function () {
              await CefSharp.BindObjectAsync("getHTMLfromjs");

              //The default is to camel case method names (the first letter of the method name is changed to lowercase)
              getHTMLfromjs.updateChange("false");

              getHTMLfromjs.updateHTMLBox(result);
            })();
          });
        }
      });

      var randid = randomId();
      if (adddivs) {
        //wrapping every element with a div having an itemname and highlight and id
        $(this).wrap("<div id='" + randid + "' class='highlight item'></div>");
      }
    }
  });*/
  /*var pastehtml = $("#pastehtml").html();
  $("#right-copy").append(pastehtml);
  setTimeout(function () {
    // Do something after 1 second
    // jQuery
    var result = $.fn.getCleanCode();

    //calling async obj
    (async function () {
      await CefSharp.BindObjectAsync("getHTMLfromjs");

      //The default is to camel case method names (the first letter of the method name is changed to lowercase)
      getHTMLfromjs.updateChange("false");
      getHTMLfromjs.updateHTMLBox(result);
    })();
  }, 600);*/
}
//need to create a temp textare to copy to clipboard because direct copy not possible
function copyToClipboard(text) {
  var dummy = document.createElement("textarea");
  // to avoid breaking orgain page when copying more words
  // cant copy when adding below this code
  // dummy.style.display = 'none'
  document.body.appendChild(dummy);
  //Be careful if you use texarea. setAttribute('value', value), which works with "input" does not work with "textarea". – Eduard
  dummy.value = text;
  dummy.select();
  document.execCommand("copy");
  document.body.removeChild(dummy);
}


function getIDofSelectedElements() {

  if ($("#right-copy").find(".clickedItem").length !== 0) {
    $("#right-copy")
      .find(".clickedItem")
      .each(function () {
        var idName = $(this).attr("id").toString();

        (async function () {
          await CefSharp.BindObjectAsync("getHTMLfromjs");

          //The default is to camel case method names (the first letter of the method name is changed to lowercase)
          getHTMLfromjs.getCSSClass(idName);
        })();
      });
  } else {

    //no clicked objects
    var idName = "noidsfound";

    (async function () {
      await CefSharp.BindObjectAsync("getHTMLfromjs");

      //The default is to camel case method names (the first letter of the method name is changed to lowercase)
      getHTMLfromjs.getCSSClass(idName);
    })();

  }

  /* setTimeout(function () {
        // Do something after 1 second
        // jQuery
        var result = $.fn.getCleanCode();

        //calling async obj
        (async function () {
            await CefSharp.BindObjectAsync("getHTMLfromjs");

            //The default is to camel case method names (the first letter of the method name is changed to lowercase)
            getHTMLfromjs.updateChange("false");
            getHTMLfromjs.updateHTMLBox(result);
        })();
    }, 600);*/
}
$("body").on("click", "img", function () {
  var ans = popupfunc("Enter image link address:");
  $(this).attr("src", ans);
});

$("body").on("click", ".customcode", function () {
  var ans = popupfunc("Enter custom code:");
  this.innerHTML = ans;
});