function selectAllElements() {
    $("#right-copy > *").filter(function () {
        if ($(this).hasClass("highlight")) {
            $(this).css("border", "2px solid #eb2d3a");
            $(this).css("background-color", "#f7ffcb");
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
    $("#right-copy")
        .find(".clickedItem")
        .each(function () {
            var tempElement = $(this);
            $(tempElement).css("border", "");
            $(tempElement).css("background-color", "");
            $(tempElement).removeClass("clickedItem");
            $(tempElement)
                .find(".editable")
                .each(function () {
                    $(this).removeClass("editable");
                    $(this).removeClass("medium-editor-element");

                    //Remove class is class="" <--- empty
                    if (!$(this).attr("class")) {
                        $(this).removeAttr("class");
                    }

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
                    .match(/((single-item-)(\d)+)/);
                if (!idcheck) {
                    var randnum = randomId();
                    $(this).attr("id", randnum);
                }
            } else {
                var randnum = randomId();
                $(this).attr("id", randnum);
            }

            copyitem = copyitem + "\n" + $(tempElement).prop("outerHTML");
        });
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
        "tidy-mark": false
    };
    var result = tidy_html5(copyitem, options);
    copyToClipboard(result);
    
}
function pasteAllElements(clipboardHTML) {
    //var editedHTML = $.parseHTML(myvar);
    var editedHTML = clipboardHTML;

    $("#pastehtml").html(editedHTML);
    var itemtype = "";
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
            var tagname = $(this)
                .prop("tagName")
                .toLowerCase();
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
                var hasanyText = $(this)
                    .text()
                    .trim().length;
                if (hasanyText != 0) {
                    $(this).addClass("editable");
                    //Medium Editor
                    var elements = document.querySelectorAll(".editable"),
                        editor = new MediumEditor(elements);
                    editor.unsubscribe("editableInput", function (event, editable) { });
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
    });
    var pastehtml = $("#pastehtml").html();
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
    }, 600);
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

function randomId() {
    var randnum =
        "single-item-" + Math.floor(100000 + Math.random() * 900000).toString();
    while ($("#" + randnum).length) {
        randnum =
            "single-item-" + Math.floor(100000 + Math.random() * 900000).toString();
    }
    return randnum;
}
