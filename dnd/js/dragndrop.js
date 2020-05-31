//Medium Editor Initialization
var editor = new MediumEditor(".editable");
editor.unsubscribe("editableInput", function(event, editable) {});
editor.subscribe("editableInput", function(event, editable) {
  // Do some work
  var result = $.fn.getCleanCode();

  //calling async obj
  (async function() {
    await CefSharp.BindObjectAsync("getHTMLfromjs");

    //The default is to camel case method names (the first letter of the method name is changed to lowercase)
    getHTMLfromjs.updateChange("false");

    getHTMLfromjs.updateHTMLBox(result);
  })();
});

var innerright = 0;
var totalitems = 0;
//dragula start
var drake = dragula([], {
  revertOnSpill: true,
  copy: function(el, source) {
    return source === document.querySelector("#left-copy");
  },
  accepts: function(el, target) {
    return target !== document.querySelector("#left-copy");
  },
  removeOnSpill: function(el, target) {
    return target !== document.querySelector("#left-copy");
  }
})
  .on("drag", function(el) {
    el.className = el.className.replace("ex-moved", "");
  })
  .on("drop", function(el) {
    var droppedid = document.getElementsByClassName(el.className)[0].id;

    //var droppedid = el.id;
    //el.className += " ex-moved";
    if (droppedid == "paragraph-item") {
      var textitem = `<p class="editable">Lorem ipsum dolor sit amet, consectetur adipiscing elit. Morbi facilisis nibh lacinia pulvinar ornare. Vivamus quis convallis turpis, in faucibus risus. Sed odio nisi, porta ut imperdiet quis, consectetur ac sapien. Aliquam pulvinar nunc id risus commodo cursus. Quisque consectetur in augue quis condimentum.</p>`;
      el.innerHTML = textitem;
    } else if (droppedid == "heading-item") {
      var textitem = `<h2 class="editable">Lorem Ipsum</h2>`;
      el.innerHTML = textitem;
    } else if (droppedid == "one-column-item") {
      innerright += 1; // to dynamically add droppable containers to dragula
      idname = "single-copy-" + innerright.toString();
      var columnitem =
        `<div class="col-sm-12 m-3 p-3 container" style="min-height:150px;" id="` +
        idname +
        `"><p class="editable">col-sm-12</p></div>`;
      el.innerHTML = columnitem;
      drake.containers.push(document.getElementById(idname));
    } else if (droppedid == "two-column-item") {
      innerright += 1; // to dynamically add droppable containers to dragula
      idnameA = "single-copy-" + innerright.toString();
      innerright += 1; // to dynamically add droppable containers to dragula
      idnameB = "single-copy-" + innerright.toString();
      var columnitem =
        `<div class="row"><div class="col-sm-6 drakecontainer" style="min-height:150px;" id="` +
        idnameA +
        `"><p class="editable">col-sm-6</p></div>
      <div class="col-sm-6 drakecontainer" style="min-height:150px;" id="` +
        idnameB +
        `"><p class="editable">col-sm-6</p></div></div>`;
      el.innerHTML = columnitem;
      drake.containers.push(document.getElementById(idnameA));
      drake.containers.push(document.getElementById(idnameB));
    } else if (droppedid == "three-column-item") {
      innerright += 1; // to dynamically add droppable containers to dragula
      idnameA = "single-copy-" + innerright.toString();
      innerright += 1; // to dynamically add droppable containers to dragula
      idnameB = "single-copy-" + innerright.toString();
      innerright += 1; // to dynamically add droppable containers to dragula
      idnameC = "single-copy-" + innerright.toString();
      var columnitem =
        `<div class="row"><div class="col-sm-4 drakecontainer" style="min-height:150px;" id="` +
        idnameA +
        `"><p class="editable">col-sm-4</p></div>
      <div class="col-sm-4 drakecontainer" style="min-height:150px;" id="` +
        idnameB +
        `"><p class="editable">col-sm-4</p></div>
        <div class="col-sm-4 drakecontainer" style="min-height:150px;" id="` +
        idnameC +
        `"><p class="editable">col-sm-4</p></div></div>`;
      el.innerHTML = columnitem;
      drake.containers.push(document.getElementById(idnameA));
      drake.containers.push(document.getElementById(idnameB));
      drake.containers.push(document.getElementById(idnameC));
    } else if (droppedid == "image-item") {
      updateUploadedItem();
      async function getUploadedItem() {
        await CefSharp.BindObjectAsync("getHTMLfromjs");

        var data = await getHTMLfromjs.uploadItem("image");
        return data;
      }
      async function updateUploadedItem() {
        var data = await getUploadedItem();
        // access results here by chaining to the returned promise
        var imageitem =
          `<img src="` + data + `" class="img-fluid" alt="Responsive image">`;
        el.innerHTML = imageitem;
        callUpdate();
      }
    } else if (droppedid == "three-by-seven-column-item") {
      innerright += 1; // to dynamically add droppable containers to dragula
      idnameA = "single-copy-" + innerright.toString();
      innerright += 1; // to dynamically add droppable containers to dragula
      idnameB = "single-copy-" + innerright.toString();
      var columnitem =
        `<div class="row"><div class="col-sm-4 drakecontainer" style="min-height:150px;" id="` +
        idnameA +
        `"><p class="editable">col-sm-4</p></div>
      <div class="col-sm-8 drakecontainer" style="min-height:150px;" id="` +
        idnameB +
        `"><p class="editable">col-sm-8</p></div>`;
      el.innerHTML = columnitem;
      drake.containers.push(document.getElementById(idnameA));
      drake.containers.push(document.getElementById(idnameB));
    } else if (droppedid == "container-item") {
      innerright += 1; // to dynamically add droppable containers to dragula
      idnameA = "single-copy-" + innerright.toString();
      var containeritem =
        `<div class="container-fluid drakecontainer" id="` +
        idnameA +
        `"><p class="editable">Container</p></div>`;
      el.innerHTML = containeritem;
      drake.containers.push(document.getElementById(idnameA));
    } else if (droppedid == "row-item") {
      innerright += 1; // to dynamically add droppable containers to dragula
      idnameA = "single-copy-" + innerright.toString();
      var rowitem =
        `<div class="row p-4 drakecontainer" id="` + idnameA + `"></div>`;
      el.innerHTML = rowitem;
      drake.containers.push(document.getElementById(idnameA));
    } else if (droppedid == "link-item") {
      var link = popupfunc("link");
      var linkitem = `<a href="` + link + `" class="editable">Click me!</a>`;
      el.innerHTML = linkitem;
    } else if (droppedid == "video-item") {
      updateUploadedItem();
      async function getUploadedItem() {
        await CefSharp.BindObjectAsync("getHTMLfromjs");

        var data = await getHTMLfromjs.uploadItem("video");
        return data;
      }
      async function updateUploadedItem() {
        var data = await getUploadedItem();
        // access results here by chaining to the returned promise
        var videoitem =
          `<div class="embed-responsive embed-responsive-16by9">
            <iframe class="embed-responsive-item" src="` +
          data +
          `" allowfullscreen allow="accelerometer; autoplay; encrypted-media; gyroscope; picture-in-picture"></iframe>
                      </div>`;
        el.innerHTML = videoitem;
        callUpdate();
      }
    } else if (droppedid == "map-item") {
      var mapitem = `<div class="mapouter">
      <div class="gmap_canvas">
      <iframe id="gmap_canvas"
      src="https://maps.google.com/maps?q=comsats%20university%20islamabad%20pakistan&t=&z=13&ie=UTF8&iwloc=&output=embed"
      frameborder="0" scrolling="no" marginheight="0" marginwidth="0"></iframe>
      </div><style>#gmap_canvas {overflow:hidden;background:none!important;width:100%;height:40vh;}</style></div>`;
      el.innerHTML = mapitem;
    } else if (droppedid == "custom-code-item") {
      var customcode = popupfunc("customcode");
      el.innerHTML = customcode;
    } else if (droppedid == "quote-item") {
      var quoteitem = `<blockquote class="blockquote editable">
                        <p class="mb-0">Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer posuere erat a ante.</p>
                        <footer class="blockquote-footer">Someone famous in <cite title="Source Title">Source Title</cite></footer>
                      </blockquote>`;
      el.innerHTML = quoteitem;
    } else if (droppedid == "text-section-item") {
      innerright += 1; // to dynamically add droppable containers to dragula
      idnameA = "single-copy-" + innerright.toString();
      var textsectionitem =
        `<section id="` +
        idnameA +
        `">
                              <h1 class="heading editable">Insert title here
                              </h1>
                              <p class="paragraph editable">Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua
                              </p>
                            </section>`;
      el.innerHTML = textsectionitem;
      drake.containers.push(document.getElementById(idnameA));
    } else if (droppedid == "navbar-item") {
      innerright += 1; // to dynamically add droppable containers to dragula
      idnameA = "single-copy-" + innerright.toString();
      var navbaritem =
        `<nav class="navbar navbar-dark bg-dark" id="` +
        idnameA +
        `">
                        <span class="navbar-text editable">
                          BootLink
                        </span>
                      </nav>`;
      el.innerHTML = navbaritem;
      drake.containers.push(document.getElementById(idnameA));
    } else if (droppedid == "tab-item") {
      innerright += 1; // to dynamically add droppable containers to dragula
      idnameA = "single-copy-" + innerright.toString();

      innerright += 1; // to dynamically add droppable containers to dragula
      idnameB = "single-copy-" + innerright.toString();

      innerright += 1; // to dynamically add droppable containers to dragula
      idnameC = "single-copy-" + innerright.toString();
      var tabitem =
        `<div data-tabs="1">
                        <nav data-tab-container="1" class="tab-container">
                          <a href="#tab1" data-tab="1" class="tab editable">Tab 1</a>
                          <a href="#tab2" data-tab="1" class="tab editable">Tab 2</a>
                          <a href="#tab3" data-tab="1" class="tab editable">Tab 3</a>
                        </nav>
                        <div id="tab1" id="` +
        idnameA +
        `" data-tab-content="1" class="editable tab-content">
                          <div>Tab 1 Content
                          </div>
                        </div>
                        <div id="tab2" id="` +
        idnameB +
        `" data-tab-content="1" class="tab-content editable">
                          <div>Tab 2 Content
                          </div>
                        </div>
                        <div id="tab3" id="` +
        idnameC +
        `" data-tab-content="1" class="tab-content editable">
                          <div>Tab 3 Content
                          </div>
                        </div>
                      </div>`;
      el.innerHTML = tabitem;
      drake.containers.push(document.getElementById(idnameA));
      drake.containers.push(document.getElementById(idnameB));
      drake.containers.push(document.getElementById(idnameC));
    } else if (droppedid == "badge-item") {
      var badgeitem = `<span class="badge badge-secondary editable">New</span>`;
      el.innerHTML = badgeitem;
    } else if (droppedid == "alert-item") {
      var alertitem = `<div class="alert alert-primary editable" role="alert">
                        A simple primary alert—check it out!
                      </div>`;
      el.innerHTML = alertitem;
    } else if (droppedid == "breadcrumbs-item") {
      var breadcrumbsitem = `<nav aria-label="breadcrumb">
                              <ol class="breadcrumb">
                                <li class="breadcrumb-item editable"><a href="#">Home</a></li>
                                <li class="breadcrumb-item active editable" aria-current="page">Library</li>
                              </ol>
                            </nav>`;
      el.innerHTML = breadcrumbsitem;
    } else if (droppedid == "button-item") {
      var buttonitem = `<button type="button" class="btn btn-primary editable">Primary</button>`;
      el.innerHTML = buttonitem;
    } else if (droppedid == "card-item") {
      innerright += 1; // to dynamically add droppable containers to dragula
      idnameA = "single-copy-" + innerright.toString();

      var carditem =
        `<div class="card" id="` +
        idnameA +
        `" style="width: 18rem;">
                        <img src="..." class="card-img-top" alt="...">
                        <div class="card-body">
                          <h5 class="card-title editable">Card title</h5>
                          <p class="card-text editable">Some quick example text to build on the card title and make up the bulk of the card's content.</p>
                          <a href="#" class="btn btn-primary editable">Go somewhere</a>
                        </div>
                      </div>`;
      el.innerHTML = carditem;
      drake.containers.push(document.getElementById(idnameA));
    } else if (droppedid == "form-item") {
      innerright += 1; // to dynamically add droppable containers to dragula
      idnameA = "single-copy-" + innerright.toString();
      var formitem =
        `<form id="` +
        idnameA +
        `">
                        <div class="form-group">
                          <label for="exampleInputEmail1">Email address</label>
                          <input type="email" class="form-control" id="exampleInputEmail1" aria-describedby="emailHelp">
                          <small id="emailHelp" class="form-text editable text-muted">We'll never share your email with anyone else.</small>
                        </div>
                        <div class="form-group">
                          <label for="exampleInputPassword1">Password</label>
                          <input type="password" class="form-control" id="exampleInputPassword1">
                        </div>
                        <div class="form-group form-check">
                          <input type="checkbox" class="form-check-input" id="exampleCheck1">
                          <label class="form-check-label" for="exampleCheck1">Check me out</label>
                        </div>
                        <button type="submit" class="btn btn-primary editable">Submit</button>
                      </form>`;
      el.innerHTML = formitem;
      drake.containers.push(document.getElementById(idnameA));
    } else if (droppedid == "input-group-item") {
      var inputgroupitem = `<div class="input-group flex-nowrap">
                              <div class="input-group-prepend">
                                <span class="input-group-text" id="addon-wrapping">@</span>
                              </div>
                              <input type="text" class="form-control editable" placeholder="Username" aria-label="Username" aria-describedby="addon-wrapping">
                            </div>`;
      el.innerHTML = inputgroupitem;
    } else if (droppedid == "jumbotron-item") {
      innerright += 1; // to dynamically add droppable containers to dragula
      idnameA = "single-copy-" + innerright.toString();

      var jumbotronitem =
        `<div class="jumbotron" id="` +
        idnameA +
        `">
                            <h1 class="display-4 editable">Hello, world!</h1>
                            <p class="lead editable">This is a simple hero unit, a simple jumbotron-style component for calling extra attention to featured content or information.</p>
                            <hr class="my-4">
                            <p class="editable">It uses utility classes for typography and spacing to space content out within the larger container.</p>
                            <a class="btn btn-primary btn-lg editable" href="#" role="button">Learn more</a>
                          </div>`;
      el.innerHTML = jumbotronitem;
      drake.containers.push(document.getElementById(idnameA));
    } else if (droppedid == "list-group-item") {
      var listgroupitem = `<ul class="list-group">
                            <li class="list-group-item editable">Cras justo odio</li>
                            <li class="list-group-item editable">Dapibus ac facilisis in</li>
                            <li class="list-group-item editable">Morbi leo risus</li>
                            <li class="list-group-item editable">Porta ac consectetur ac</li>
                            <li class="list-group-item editable">Vestibulum at eros</li>
                          </ul>`;
      el.innerHTML = listgroupitem;
    } else if (droppedid == "pagination-item") {
      var paginationitem = `<nav aria-label="Page navigation example">
                              <ul class="pagination">
                                <li class="page-item"><a class="page-link" href="#">Previous</a></li>
                                <li class="page-item"><a class="page-link" href="#">1</a></li>
                                <li class="page-item"><a class="page-link" href="#">2</a></li>
                                <li class="page-item"><a class="page-link" href="#">3</a></li>
                                <li class="page-item"><a class="page-link" href="#">Next</a></li>
                              </ul>
                            </nav>`;
      el.innerHTML = paginationitem;
    } else if (droppedid == "popover-item") {
      var popoveritem = `<button type="button" class="btn btn-lg btn-danger editable" data-placement="top" data-toggle="popover" title="Popover title" data-content="And here's some amazing content. It's very engaging. Right?">Click to toggle popover</button>`;
      el.innerHTML = popoveritem;
    } else if (droppedid == "progress-bar-item") {
      var progressbaritem = `<div class="progress">
                              <div class="progress-bar" role="progressbar" style="width: 25%;" aria-valuenow="25" aria-valuemin="0" aria-valuemax="100">25%</div>
                            </div>`;
      el.innerHTML = progressbaritem;
    } else if (droppedid == "tooltip-item") {
      var tooltipitem = `<button type="button" class="btn btn-secondary editable" data-toggle="tooltip" data-placement="top" title="Tooltip on top">
                          Tooltip on top
                        </button>`;
      el.innerHTML = tooltipitem;
    } else if (droppedid == "dropdown-item") {
      var dropdownitem = `<div class="dropdown">
                            <a class="btn btn-secondary dropdown-toggle editable" href="#" role="button" id="dropdownMenuLink" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                              Dropdown link
                            </a>

                            <div class="dropdown-menu" aria-labelledby="dropdownMenuLink">
                              <a class="dropdown-item editable" href="#">Action</a>
                              <a class="dropdown-item editable" href="#">Another action</a>
                              <a class="dropdown-item editable" href="#">Something else here</a>
                            </div>
                          </div>`;
      el.innerHTML = dropdownitem;
    } else if (droppedid == "carousel-item") {
      var carouselitem = `<div id="carouselExampleIndicators" class="carousel slide" data-ride="carousel">
                        <ol class="carousel-indicators">
                          <li data-target="#carouselExampleIndicators" data-slide-to="0" class="active"></li>
                          <li data-target="#carouselExampleIndicators" data-slide-to="1"></li>
                          <li data-target="#carouselExampleIndicators" data-slide-to="2"></li>
                        </ol>
                        <div class="carousel-inner">
                          <div class="carousel-item active">
                            <img src="https://via.placeholder.com/500" class="d-block w-100" alt="...">
                          </div>
                          <div class="carousel-item">
                            <img src="https://via.placeholder.com/500" class="d-block w-100" alt="...">
                          </div>
                          <div class="carousel-item">
                            <img src="https://via.placeholder.com/500" class="d-block w-100" alt="...">
                          </div>
                        </div>
                        <a class="carousel-control-prev" href="#carouselExampleIndicators" role="button" data-slide="prev">
                          <span class="carousel-control-prev-icon" aria-hidden="true"></span>
                          <span class="sr-only">Previous</span>
                        </a>
                        <a class="carousel-control-next" href="#carouselExampleIndicators" role="button" data-slide="next">
                          <span class="carousel-control-next-icon" aria-hidden="true"></span>
                          <span class="sr-only">Next</span>
                        </a>
                      </div>`;
      el.innerHTML = carouselitem;
    }

    el.className += " highlight";
    totalitems += 1;
    el.className += " single-item-" + totalitems;
    //Medium Editor
    var elements = document.querySelectorAll(".editable"),
      editor = new MediumEditor(elements);
    editor.subscribe("editableInput", function(event, editable) {
      // Do some work
      var result = $.fn.getCleanCode();

      //calling async obj

      (async function() {
        await CefSharp.BindObjectAsync("getHTMLfromjs");

        //The default is to camel case method names (the first letter of the method name is changed to lowercase)
        getHTMLfromjs.updateChange("false");
        getHTMLfromjs.updateHTMLBox(result);
      })();
    });

    setTimeout(function() {
      // Do something after 1 second
      // jQuery
      var result = $.fn.getCleanCode();

      //calling async obj
      (async function() {
        await CefSharp.BindObjectAsync("getHTMLfromjs");

        //The default is to camel case method names (the first letter of the method name is changed to lowercase)
        getHTMLfromjs.updateChange("false");
        getHTMLfromjs.updateHTMLBox(result);
      })();
    }, 600);
  })
  .on("over", function(el, container) {
    container.className += " ex-over";
  })
  .on("out", function(el, container) {
    container.className = container.className.replace("ex-over", "");
  });

drake.containers.push(document.getElementById("left-copy"));
drake.containers.push(document.getElementById("right-copy"));

function callUpdate() {
  var result = $.fn.getCleanCode();

  //calling async obj

  (async function() {
    await CefSharp.BindObjectAsync("getHTMLfromjs");

    //The default is to camel case method names (the first letter of the method name is changed to lowercase)
    getHTMLfromjs.updateChange("false");
    getHTMLfromjs.updateHTMLBox(result);
  })();
}
$.fn.getCleanCode = function() {
  var html = $("#right-copy")[0].innerHTML.toString();
  $(".myhtml").html(html);

  //stating the removing
  //removing class of highlight
  $(".myhtml")
    .find(".highlight")
    .each(function() {
      $(this).css("border", "");
      $(this).css("background-color", "");
      $(this).css("color", "");
      $(this).removeClass("highlight");

      //Remove class is class="" <--- empty else add a space
      if (!$(this).attr("class")) {
        $(this).removeAttr("class");
      } else {
        $(this).addClass(" ");
      }
    });

  //removing styles if elements is/are clicked
  $(".myhtml")
    .find(".clickedItem")
    .each(function() {
      $(this).css("border", "");
      $(this).css("background-color", "");
      $(this).removeClass("clickedItem");
    });

  //removing attributes that are unnecessary
  $(".myhtml > *").filter(function() {
    var style = $(this).attr("style");

    if ($(this).attr("style") == undefined) {
      $(this).removeAttr("style");
    }
    if (
      $(this).attr("class") &&
      ($(this).attr("class", "") || $(this).attr("class", " "))
    ) {
      $(this).removeAttr("class");
    }
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
  });
  //removing medium api classes and attributes
  $(".myhtml")
    .find(".editable")
    .each(function() {
      //Removing medium classes editable medium-editor-element
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
      $(this).removeAttr("style");
      $(this).addClass(" ");
    });

  //using tidy.js for html5 formatting
  options = {
    indent: "auto",
    "indent-spaces": 2,
    wrap: 80,
    markup: true,
    "output-xml": true,
    "numeric-entities": true,
    "quote-marks": true,
    "quote-nbsp": false,
    "show-body-only": false,
    "quote-ampersand": false,
    "break-before-br": true,
    "uppercase-tags": false,
    "uppercase-attributes": false,
    "drop-font-tags": true,
    "tidy-mark": false,
    doctype: "omit"
  };

  var html = $(".myhtml").html();

  html =
    `<html id="single-item-html">
  <head id="single-item-head">
  <title id="single-item-title">My Website</title>
  <link id="single-item-link1" rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.4.1/css/bootstrap.min.css" />
  <link id="single-item-link2" rel="stylesheet" href="main.css" />
  </head>
  <body id="single-item-body">` +
    html +
    `
    
</body><script src="https://code.jquery.com/jquery-3.4.1.slim.min.js" integrity="sha384-J6qa4849blE2+poT4WnyKhv5vZF5SrPo0iEjwBvKU7imGFAV0wwj1yYfoRSJoZ+n" crossorigin="anonymous" id="single-item-script1"></script>
<script src="https://cdn.jsdelivr.net/npm/popper.js@1.16.0/dist/umd/popper.min.js" integrity="sha384-Q6E9RHvbIyZFJoft+2mJbHaEWldlvI9IOYy5n3zV9zzTtmI3UksdQRVvoxMfooAo" crossorigin="anonymous" id="single-item-script2"></script>
<script src="https://stackpath.bootstrapcdn.com/bootstrap/4.4.1/js/bootstrap.min.js" integrity="sha384-wfSDF2E50Y2D1uUdj0O3uMBJnjuUD4Ih7YwaYd1iqfktj0Uod8GCExl3Og8ifwB6" crossorigin="anonymous" id="single-item-script3"></script></html>`;

  var result = tidy_html5(html, options);
  $(".myhtml").empty();

  return result;
};

function testFunc(myvar) {
  var csharpHTML = myvar;
  //taking string betw
  var editedhtml = csharpHTML.match('body">((.|[\r\n])*?)<script');
  editedhtml = editedhtml[1];
  $("#right-copy").html(editedhtml);

  var itemtype = "";
  var addeditable = false;
  var addtags = false;
  var adddivs = false;
  var adddrakecontainer = false;

  $("#right-copy > *").filter(function() {
    //removing styles if elements is/are clicked
    if ($(this).attr("class") && $(this).hasClass("clickedItem")) {
      $(this).css("border", "");
      $(this).css("background-color", "");
      $(this).removeClass("clickedItem");
    }
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
      } else {
        adddivs = true;
      }

      var currentHTML = $(this)[0];

      var hasanyText = $(this)
        .text()
        .trim().length;
      if (hasanyText != 0) {
        $(this).addClass("editable");
        //Medium Editor
        var elements = document.querySelectorAll(".editable"),
          editor = new MediumEditor(elements);
        editor.unsubscribe("editableInput", function(event, editable) {});
        editor.subscribe("editableInput", function(event, editable) {
          // Do some work
          var result = $.fn.getCleanCode();

          //calling async obj
          (async function() {
            await CefSharp.BindObjectAsync("getHTMLfromjs");

            //The default is to camel case method names (the first letter of the method name is changed to lowercase)
            getHTMLfromjs.updateChange("false");

            getHTMLfromjs.updateHTMLBox(result);
          })();
        });
      }

      var randid = randomId();
      if (adddivs) {
        //wrapping every element with a div having an itemname and highlight and id
        $(this).wrap("<div id='" + randid + "' class='highlight item'></div>");
      }

      //updating the div
      var result = $.fn.getCleanCode();

      //calling async obj
      (async function() {
        await CefSharp.BindObjectAsync("getHTMLfromjs");

        //The default is to camel case method names (the first letter of the method name is changed to lowercase)
        getHTMLfromjs.updateChange("false");
        getHTMLfromjs.updateHTMLBox(result);
      })();
    }
  });
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
