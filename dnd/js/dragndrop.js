//Id checker
var idnum = 1;
//Medium Editor Initialization
var editor = new MediumEditor(".editable");
editor.unsubscribe("editableInput", function (event, editable) {});

editor.subscribe("editableInput", function (event, editable) {
  // Do some work
  var result = $.fn.getCleanCode();

  //binding object

  //calling async obj
  (async function () {
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
    copy: function (el, source) {
      return source === document.querySelector("#left-copy");
    },
    accepts: function (el, target) {
      return target !== document.querySelector("#left-copy");
    },
    revertOnSpill: function (el, target) {
      return target !== document.querySelector("#left-copy");
    },
    moves: (el, source, handle, sibling) => !el.classList.contains("unitem"),
  })
  .on("drag", function (el) {
    el.className = el.className.replace("ex-moved", "");
  })
  .on("drop", function (el) {
    var droppedid = document.getElementsByClassName(el.className)[0].id;
    document.getElementsByClassName(el.className)[0].id =
      "single-item-" + idnum.toString();
    idnum += 1;
    //var droppedid = el.id;
    //el.className += " ex-moved";
    if (droppedid == "paragraph-item") {
      $(el).attr("id", "single-item-" + idnum);
      idnum++;
      var textitem =
        `<p id="single-item-` +
        idnum +
        `" class="editable highlight">Lorem ipsum dolor sit amet, consectetur adipiscing elit. Morbi facilisis nibh lacinia pulvinar ornare. Vivamus quis convallis turpis, in faucibus risus. Sed odio nisi, porta ut imperdiet quis, consectetur ac sapien. Aliquam pulvinar nunc id risus commodo cursus. Quisque consectetur in augue quis condimentum.</p>`;
      idnum++;
      el.innerHTML = textitem;
    } else if (droppedid == "heading-item") {
      $(el).attr("id", "single-item-" + idnum);
      idnum++;
      var textitem =
        `<h2 id="single-item-` + idnum + `" class="editable highlight">Lorem Ipsum</h2>`;
      idnum++;

      el.innerHTML = textitem;
    } else if (droppedid == "navs-item") {
      $(el).attr("id", "single-item-" + idnum);
      idnum++;
      var textitem =
        `<ul class="nav highlight editable">
        <li class="nav-item" id="single-item-` +
        idnum +
        `">
          <a class="nav-link active" href="#" id="single-item-` +
        idnum +
        `">Active</a>
        </li>
        <li class="nav-item" id="single-item-` +
        idnum +
        `">
          <a class="nav-link" href="#" id="single-item-` +
        idnum +
        `">Link</a>
        </li>
        <li class="nav-item" id="single-item-` +
        idnum +
        `">
          <a class="nav-link" href="#" id="single-item-` +
        idnum +
        `">Link</a>
        </li>
        <li class="nav-item" id="single-item-` +
        idnum +
        `">
          <a class="nav-link disabled" href="#" tabindex="-1" aria-disabled="true" id="single-item-` +
        idnum +
        `">Disabled</a>
        </li>
      </ul>`;
      idnum++;

      el.innerHTML = textitem;
    } else if (droppedid == "one-column-item") {
      $(el).attr("id", "single-item-" + idnum);
      idnum++;
      var dividA = "single-item-" + idnum;
      idnum++;
      var columnitem =
        `<div class="col-sm-12 m-3 p-3 container" style="min-height:50px;" id="` +
        dividA +
        `"><p id="single-item-` +
        idname +
        `" class="editable highlight">col-sm-12</p></div>`;
      idname++;
      el.innerHTML = columnitem;
      drake.containers.push(document.getElementById(dividA));
    } else if (droppedid == "two-column-item") {
      $(el).attr("id", "single-item-" + idnum);
      idnum++;
      var dividA = "single-item-" + idnum;
      idnum++;
      var dividB = "single-item-" + idnum;
      idnum++;
      var dividC = "single-item-" + idnum;
      idnum++;
      var pidA = "single-item-" + idnum;
      idnum++;
      var pidB = "single-item-" + idnum;
      idnum++;
      var columnitem =
        `<div id="` +
        dividA +
        `" class="row"><div class="col-sm-6 drakecontainer" style="min-height:50px;" id="` +
        dividB +
        `"><p id="` +
        pidA +
        `" class="editable highlight">col-sm-6</p></div>
      <div class="col-sm-6 drakecontainer" style="min-height:50px;" id="` +
        dividC +
        `"><p id="` +
        pidB +
        `" class="editable highlight">col-sm-6</p></div></div>`;
      el.innerHTML = columnitem;
      drake.containers.push(document.getElementById(dividA));
      drake.containers.push(document.getElementById(dividB));
      drake.containers.push(document.getElementById(dividC));
    } else if (droppedid == "three-column-item") {
      $(el).attr("id", "single-item-" + idnum);
      idnum++;
      var dividA = "single-item-" + idnum;
      idnum++;
      var dividB = "single-item-" + idnum;
      idnum++;
      var dividC = "single-item-" + idnum;
      idnum++;
      var dividD = "single-item-" + idnum;
      idnum++;
      var pidA = "single-item-" + idnum;
      idnum++;
      var pidB = "single-item-" + idnum;
      idnum++;
      var pidC = "single-item-" + idnum;
      idnum++;
      var columnitem =
        `<div id="` +
        dividA +
        `" class="row"><div class="col-sm-4 drakecontainer" style="min-height:50px;" id="` +
        dividB +
        `"><p id="` +
        pidA +
        `" class="editable highlight">col-sm-4</p></div>
      <div class="col-sm-4 drakecontainer" style="min-height:50px;" id="` +
        dividC +
        `"><p id="` +
        pidB +
        `" class="editable highlight">col-sm-4</p></div>
        <div class="col-sm-4 drakecontainer" style="min-height:50px;" id="` +
        dividD +
        `"><p id="` +
        pidC +
        `" class="editable highlight">col-sm-4</p></div></div>`;
      el.innerHTML = columnitem;
      drake.containers.push(document.getElementById(dividA));
      drake.containers.push(document.getElementById(dividB));
      drake.containers.push(document.getElementById(dividC));
      drake.containers.push(document.getElementById(dividD));
    } else if (droppedid == "image-item") {
      $(el).attr("id", "single-item-" + idnum);
      idnum++;
      var imgidA = "single-item-" + idnum;
      idnum++;
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
          `<img id="` +
          imgidA +
          `" src="` +
          data +
          `" class="img-fluid" alt="Responsive image" />`;
        el.innerHTML = imageitem;
        callUpdate();
      }
    } else if (droppedid == "three-by-seven-column-item") {
      $(el).attr("id", "single-item-" + idnum);
      idnum++;
      var dividA = "single-item-" + idnum;
      idnum++;
      var dividB = "single-item-" + idnum;
      idnum++;
      var dividC = "single-item-" + idnum;
      idnum++;
      var pidA = "single-item-" + idnum;
      idnum++;
      var pidB = "single-item-" + idnum;
      idnum++;
      var columnitem =
        `<div id="` +
        dividA +
        `" class="row"><div class="col-sm-4 drakecontainer" style="min-height:50px;" id="` +
        dividB +
        `"><p id="` +
        pidA +
        `" class="editable highlight">col-sm-4</p></div>
      <div class="col-sm-8 drakecontainer" style="min-height:50px;" id="` +
        dividC +
        `"><p id="` +
        pidB +
        `" class="editable">col-sm-8</p></div>`;
      el.innerHTML = columnitem;
      drake.containers.push(document.getElementById(dividA));
      drake.containers.push(document.getElementById(dividB));
      drake.containers.push(document.getElementById(dividC));
    } else if (droppedid == "container-item") {
      $(el).attr("id", "single-item-" + idnum);
      idnum++;
      var dividA = "single-item-" + idnum;
      idnum++;
      var pidA = "single-item-" + idnum;
      idnum++;
      var containeritem =
        `<div class="container-fluid drakecontainer" id="` +
        dividA +
        `"><p id="` +
        pidA +
        `" class="editable highlight">Container</p></div>`;
      el.innerHTML = containeritem;
      drake.containers.push(document.getElementById(dividA));
    } else if (droppedid == "row-item") {
      $(el).attr("id", "single-item-" + idnum);
      idnum++;
      var dividA = "single-item-" + idnum;
      idnum++;
      var pidA = "single-item-" + idnum;
      idnum++;
      var rowitem =
        `<div class="row p-4 drakecontainer" id="` +
        dividA +
        `"><p id="` +
        pidA +
        `" class="editable highlight">Row</p></div>`;
      el.innerHTML = rowitem;
      drake.containers.push(document.getElementById(idnameA));
    } else if (droppedid == "link-item") {
      $(el).attr("id", "single-item-" + idnum);
      idnum++;
      var linkidA = "single-item-" + idnum;
      idnum++;

      var link = popupfunc("link");
      var linkitem = `<a id="` + linkidA + `" href="` + link + `" class="editable highlight">Click me!</a>`;
      el.innerHTML = linkitem;
    } else if (droppedid == "video-item") {
      $(el).attr("id", "single-item-" + idnum);
      idnum++;
      var dividA = "single-item-" + idnum;
      idnum++;
      var iframeidA = "single-item-" + idnum;
      idnum++;
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
          `<div id="` + dividA + `" class="embed-responsive embed-responsive-16by9">
            <iframe id="` + iframeidA + `" class="embed-responsive-item" src="` +
          data +
          `" allowfullscreen allow="accelerometer; autoplay; encrypted-media; gyroscope; picture-in-picture"></iframe>
                      </div>`;
        el.innerHTML = videoitem;
        callUpdate();
      }
    } else if (droppedid == "map-item") {
      $(el).attr("id", "single-item-" + idnum);
      idnum++;
      var dividA = "single-item-" + idnum;
      idnum++;
      var dividB = "single-item-" + idnum;
      idnum++;
      var iframeidA = "single-item-" + idnum;
      idnum++;
      var styleidA = "single-item-" + idnum;
      idnum++;
      var mapitem = `<div id="` + dividA + `" class="mapouter">
      <div id="` + dividB + `" class="gmap_canvas">
      <iframe id="` + iframeidA + `"
      src="https://maps.google.com/maps?q=comsats%20university%20islamabad%20pakistan&t=&z=13&ie=UTF8&iwloc=&output=embed"
      frameborder="0" scrolling="no" marginheight="0" marginwidth="0"></iframe>
      </div><style id="` + styleidA + `">#` + iframeidA + ` {overflow:hidden;background:none!important;width:100%;height:40vh;}</style></div>`;
      el.innerHTML = mapitem;
    } else if (droppedid == "custom-code-item") {
      $(el).attr("id", "single-item-" + idnum);
      idnum++;
      var customcodeidA = "single-item-" + idnum;
      idnum++;
      var customcode = popupfunc("customcode");
      customcode = `<div id="` + customcodeidA + `" class="customcode">` + customcode + `</div>`;
      el.innerHTML = customcode;
    } else if (droppedid == "quote-item") {
      $(el).attr("id", "single-item-" + idnum);
      idnum++;
      var blockquoteidA = "single-item-" + idnum;
      idnum++;
      var pidA = "single-item-" + idnum;
      idnum++;
      var footeridA = "single-item-" + idnum;
      idnum++;
      var quoteitem = `<blockquote id="` + blockquoteidA + `" class="blockquote editable">
                        <p id="` + pidA + `" class="mb-0">Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer posuere erat a ante.</p>
                        <footer id="` + footeridA + `" class="blockquote-footer">Someone famous in <cite title="Source Title">Source Title</cite></footer>
                      </blockquote>`;
      el.innerHTML = quoteitem;
    } else if (droppedid == "text-section-item") {
      $(el).attr("id", "single-item-" + idnum);
      idnum++;
      var sectionidA = "single-item-" + idnum;
      idnum++;
      var honeidA = "single-item-" + idnum;
      idnum++;
      var pidA = "single-item-" + idnum;
      idnum++;
      var textsectionitem =
        `<section id="` +
        sectionidA +
        `" class="drakecontainer">
                              <h1  id="` +
        honeidA +
        `" class="heading editable highlight">Insert title here
                              </h1>
                              <p id="` +
        pidA +
        `" class="paragraph editable highlight">Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua
                              </p>
                            </section>`;
      el.innerHTML = textsectionitem;
      drake.containers.push(document.getElementById(sectionidA));
    } else if (droppedid == "navbar-item") {
      $(el).attr("id", "single-item-" + idnum);
      idnum++;
      var navbaridA = "single-item-" + idnum;
      idnum++;
      var spanidA = "single-item-" + idnum;
      idnum++;
      var navbaritem =
        `<nav class="navbar navbar-dark bg-dark" id="` +
        navbaridA +
        `">
                        <span id="` +
        spanidA +
        `" class="navbar-text editable highlight">
                          BootLink
                        </span>
                      </nav>`;
      el.innerHTML = navbaritem;
      drake.containers.push(document.getElementById(navbaridA));
    } else if (droppedid == "tab-item") {
      $(el).attr("id", "single-item-" + idnum);
      idnum++;
      var dividA = "single-item-" + idnum;
      idnum++;
      var dividB = "single-item-" + idnum;
      idnum++;
      var dividC = "single-item-" + idnum;
      idnum++;
      var dividD = "single-item-" + idnum;
      idnum++;
      var dividE = "single-item-" + idnum;
      idnum++;
      var dividF = "single-item-" + idnum;
      idnum++;
      var dividG = "single-item-" + idnum;
      idnum++;
      var navidA = "single-item-" + idnum;
      idnum++;
      var aidA = "single-item-" + idnum;
      idnum++;
      var aidB = "single-item-" + idnum;
      idnum++;
      var aidC = "single-item-" + idnum;
      idnum++;
      var tabitem =
        `<div id="` + dividA + `" data-tabs="1">
                        <nav id="` + navidA + `" data-tab-container="1" class="tab-container">
                          <a id="` + aidA + `" href="#` + dividB + `" data-tab="1" class="tab editable">Tab 1</a>
                          <a id="` + aidB + `" href="#` + dividC + `" data-tab="1" class="tab editable">Tab 2</a>
                          <a id="` + aidC + `" href="#` + dividD + `" data-tab="1" class="tab editable">Tab 3</a>
                        </nav>
                        <div id="` +
        dividB +
        `" data-tab-content="1" class="tab-content">
                          <div id="` + dividE + `" class="editable highlight">Tab 1 Content
                          </div>
                        </div>
                        <div id="` +
        dividC +
        `" data-tab-content="1" class="tab-content">
                          <div id="` + dividF + `" class="editable highlight">Tab 2 Content
                          </div>
                        </div>
                        <div id="` +
        dividD +
        `" data-tab-content="1" class="tab-content">
                          <div id="` + dividG + `" class="editable highlight">Tab 3 Content
                          </div>
                        </div>
                      </div>`;
      el.innerHTML = tabitem;
      drake.containers.push(document.getElementById(dividB));
      drake.containers.push(document.getElementById(dividC));
      drake.containers.push(document.getElementById(dividD));
    } else if (droppedid == "badge-item") {
      $(el).attr("id", "single-item-" + idnum);
      idnum++;
      var badgeidA = "single-item-" + idnum;
      idnum++;
      var badgeitem = `<span id="` + badgeidA + `" class="badge badge-secondary editable">New</span>`;
      el.innerHTML = badgeitem;
    } else if (droppedid == "alert-item") {
      $(el).attr("id", "single-item-" + idnum);
      idnum++;
      var divalertidA = "single-item-" + idnum;
      idnum++;
      var alertitem = `<div id="` + divalertidA + `" class="alert alert-primary editable" role="alert">
                        A simple primary alert—check it out!
                      </div>`;
      el.innerHTML = alertitem;
    } else if (droppedid == "breadcrumbs-item") {
      $(el).attr("id", "single-item-" + idnum);
      idnum++;
      var navidA = "single-item-" + idnum;
      idnum++;
      var olidA = "single-item-" + idnum;
      idnum++;
      var liidA = "single-item-" + idnum;
      idnum++;
      var liidA = "single-item-" + idnum;
      idnum++;
      var breadcrumbsitem = `<nav id="` + navidA + `" aria-label="breadcrumb">
                              <ol id="` + olidA + `" class="breadcrumb">
                                <li id="` + liidA + `" class="breadcrumb-item editable"><a href="#">Home</a></li>
                                <li id="` + liidB + `" class="breadcrumb-item active editable" aria-current="page">Library</li>
                              </ol>
                            </nav>`;
      el.innerHTML = breadcrumbsitem;
    } else if (droppedid == "button-item") {
      $(el).attr("id", "single-item-" + idnum);
      idnum++;
      var buttonidA = "single-item-" + idnum;
      idnum++;
      var buttonitem = `<button id="` + buttonidA + `" type="button" class="btn btn-primary editable highlight">Primary</button>`;
      el.innerHTML = buttonitem;
    } else if (droppedid == "card-item") {
      $(el).attr("id", "single-item-" + idnum);
      idnum++;
      var dividA = "single-item-" + idnum;
      idnum++;
      var dividB = "single-item-" + idnum;
      idnum++;
      var aidA = "single-item-" + idnum;
      idnum++;
      var hfiveidA = "single-item-" + idnum;
      idnum++;
      var pidA = "single-item-" + idnum;
      idnum++;
      var imgidA = "single-item-" + idnum;
      idnum++;

      var carditem =
        `<div class="card" id="` +
        dividA +
        `" style="width: 18rem;">
                        <img id="` +
        imgidA +
        `" src="https://picsum.photos/350/400" class="card-img-top highlight" alt="Card Image" />
                        <div id="` +
        dividB +
        `" class="card-body">
                          <h5 id="` + hfiveidA + `" class="card-title editable highlight">Card title</h5>
                          <p id="` + pidA + `" class="card-text editable highlight">Some quick example text to build on the card title and make up the bulk of the card's content.</p>
                          <a id="` + aidA + `" href="#" class="btn btn-primary editable highlight">Go somewhere</a>
                        </div>
                      </div>`;
      el.innerHTML = carditem;
      drake.containers.push(document.getElementById(dividA));
      drake.containers.push(document.getElementById(dividB));
    } else if (droppedid == "form-item") {
      $(el).attr("id", "single-item-" + idnum);
      idnum++;
      var formidA = "single-item-" + idnum;
      idnum++;
      var dividA = "single-item-" + idnum;
      idnum++;
      var dividB = "single-item-" + idnum;
      idnum++;
      var dividC = "single-item-" + idnum;
      idnum++;
      var buttonidA = "single-item-" + idnum;
      idnum++;
      var labelidA = "single-item-" + idnum;
      idnum++;
      var labelidB = "single-item-" + idnum;
      idnum++;
      var labelidC = "single-item-" + idnum;
      idnum++;
      var inputidA = "single-item-" + idnum;
      idnum++;
      var inputidB = "single-item-" + idnum;
      idnum++;
      var inputidC = "single-item-" + idnum;
      idnum++;
      var smallidA = "single-item-" + idnum;
      idnum++;

      var formitem =
        `<form id="` +
        formidA +
        `">
                        <div id="` + dividA + `" class="form-group">
                          <label id="` + labelidA + `" for="exampleInputEmail1">Email address</label>
                          <input id="` + inputidA + `" type="email" class="form-control" id="exampleInputEmail1" aria-describedby="emailHelp">
                          <small id="` + smallidA + `" id="emailHelp" class="form-text editable text-muted">We'll never share your email with anyone else.</small>
                        </div>
                        <div id="` + dividB + `" class="form-group">
                          <label id="` + labelidB + `" for="exampleInputPassword1">Password</label>
                          <input id="` + inputidB + `" type="password" class="form-control" id="exampleInputPassword1">
                        </div>
                        <div id="` + dividC + `" class="form-group form-check">
                          <input id="` + inputidC + `" type="checkbox" class="form-check-input" id="exampleCheck1">
                          <label id="` + labelidC + `" class="form-check-label" for="exampleCheck1">Check me out</label>
                        </div>
                        <button id="` + buttonidA + `" type="submit" class="btn btn-primary editable">Submit</button>
                      </form>`;
      el.innerHTML = formitem;
      drake.containers.push(document.getElementById(formidA));
      drake.containers.push(document.getElementById(dividA));
      drake.containers.push(document.getElementById(dividB));
      drake.containers.push(document.getElementById(dividC));
    } else if (droppedid == "input-group-item") {
      $(el).attr("id", "single-item-" + idnum);
      idnum++;
      var inputidA = "single-item-" + idnum;
      idnum++;
      var inputgroupitem = `<input id="` + inputidA + `" type="text" class="form-control editable" placeholder="Username" aria-label="Username" aria-describedby="addon-wrapping">`;
      el.innerHTML = inputgroupitem;
    } else if (droppedid == "jumbotron-item") {
      $(el).attr("id", "single-item-" + idnum);
      idnum++;
      var dividA = "single-item-" + idnum;
      idnum++;
      var honeidA = "single-item-" + idnum;
      idnum++;
      var pidA = "single-item-" + idnum;
      idnum++;
      var hridA = "single-item-" + idnum;
      idnum++;
      var pidB = "single-item-" + idnum;
      idnum++;
      var aidA = "single-item-" + idnum;
      idnum++;

      var jumbotronitem =
        `<div class="jumbotron highlight" id="` +
        dividA +
        `">
                            <h1 id="` + honeidA + `" class="display-4 editable highlight">Hello, world!</h1>
                            <p id="` + pidA + `" class="lead editable">This is a simple hero unit, a simple jumbotron-style component for calling extra attention to featured content or information.</p>
                            <hr id="` + hridA + `" class="my-4">
                            <p id="` + pidA + `" class="editable">It uses utility classes for typography and spacing to space content out within the larger container.</p>
                            <a id="` + aidA + `" class="btn btn-primary btn-lg editable" href="#" role="button">Learn more</a>
                          </div>`;
      el.innerHTML = jumbotronitem;
      drake.containers.push(document.getElementById(dividA));
    } else if (droppedid == "list-group-item") {
      $(el).attr("id", "single-item-" + idnum);
      idnum++;
      var ulidA = "single-item-" + idnum;
      idnum++;
      var liidA = "single-item-" + idnum;
      idnum++;
      var liidB = "single-item-" + idnum;
      idnum++;
      var liidC = "single-item-" + idnum;
      idnum++;
      var liidD = "single-item-" + idnum;
      idnum++;
      var liidE = "single-item-" + idnum;
      idnum++;
      var listgroupitem = `<ul id="` + ulidA + `" class="list-group editable highlight">
                            <li id="` + liidA + `" class="list-group-item ">Cras justo odio</li>
                            <li id="` + liidB + `" class="list-group-item ">Dapibus ac facilisis in</li>
                            <li id="` + liidC + `" class="list-group-item ">Morbi leo risus</li>
                            <li id="` + liidD + `" class="list-group-item ">Porta ac consectetur ac</li>
                            <li id="` + liidE + `" class="list-group-item ">Vestibulum at eros</li>
                          </ul>`;
      el.innerHTML = listgroupitem;
    } else if (droppedid == "pagination-item") {
      $(el).attr("id", "single-item-" + idnum);
      idnum++;
      var navidA = "single-item-" + idnum;
      idnum++;
      var ulidA = "single-item-" + idnum;
      idnum++;
      var liidA = "single-item-" + idnum;
      idnum++;
      var liidB = "single-item-" + idnum;
      idnum++;
      var liidC = "single-item-" + idnum;
      idnum++;
      var liidD = "single-item-" + idnum;
      idnum++;
      var liidE = "single-item-" + idnum;
      idnum++;
      var paginationitem = `<nav id="` + navidA + `" aria-label="Page navigation example">
                              <ul id="` + ulidA + `" class="pagination editable highlight">
                                <li id="` + liidA + `" class="page-item"><a class="page-link" href="#">Previous</a></li>
                                <li id="` + liidB + `" class="page-item"><a class="page-link" href="#">1</a></li>
                                <li id="` + liidC + `" class="page-item"><a class="page-link" href="#">2</a></li>
                                <li id="` + liidD + `" class="page-item"><a class="page-link" href="#">3</a></li>
                                <li id="` + liidE + `" class="page-item"><a class="page-link" href="#">Next</a></li>
                              </ul>
                            </nav>`;
      el.innerHTML = paginationitem;
    } else if (droppedid == "popover-item") {
      $(el).attr("id", "single-item-" + idnum);
      idnum++;
      var buttonidA = "single-item-" + idnum;
      idnum++;
      var popoveritem = `<button id="` + buttonidA + `" type="button" class="btn btn-lg btn-danger editable" data-placement="top" data-toggle="popover" title="Popover title" data-content="And here's some amazing content. It's very engaging. Right?">Click to toggle popover</button>`;
      el.innerHTML = popoveritem;
    } else if (droppedid == "progress-bar-item") {
      $(el).attr("id", "single-item-" + idnum);
      idnum++;
      var dividA = "single-item-" + idnum;
      idnum++;
      var dividB = "single-item-" + idnum;
      idnum++;
      var progressbaritem = `<div id="` + dividA + `" class="progress">
                              <div id="` + dividB + `" class="progress-bar" role="progressbar" style="width: 25%;" aria-valuenow="25" aria-valuemin="0" aria-valuemax="100">25%</div>
                            </div>`;
      el.innerHTML = progressbaritem;
    } else if (droppedid == "tooltip-item") {
      $(el).attr("id", "single-item-" + idnum);
      idnum++;
      var tooltipidA = "single-item-" + idnum;
      idnum++;
      var tooltipitem = `<button id="` + tooltipidA + `" type="button" class="btn btn-secondary editable" data-toggle="tooltip" data-placement="top" title="Tooltip on top">
                          Tooltip on top
                        </button>`;
      el.innerHTML = tooltipitem;
    } else if (droppedid == "dropdown-item") {
      $(el).attr("id", "single-item-" + idnum);
      idnum++;
      var dividA = "single-item-" + idnum;
      idnum++;
      var aidA = "single-item-" + idnum;
      idnum++;
      var dividB = "single-item-" + idnum;
      idnum++;
      var aidB = "single-item-" + idnum;
      idnum++;
      var aidC = "single-item-" + idnum;
      idnum++;
      var aidD = "single-item-" + idnum;
      idnum++;
      var dropdownitem = `<div id="` + dividA + `" class="dropdown editable highlight">
                            <a id="` + aidA + `" class="btn btn-secondary dropdown-toggle " href="#" role="button" id="dropdownMenuLink" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                              Dropdown link
                            </a>

                            <div id="` + dividB + `" class="dropdown-menu" aria-labelledby="dropdownMenuLink">
                              <a id="` + aidB + `" class="dropdown-item " href="#">Action</a>
                              <a id="` + aidC + `" class="dropdown-item " href="#">Another action</a>
                              <a id="` + aidD + `" class="dropdown-item " href="#">Something else here</a>
                            </div>
                          </div>`;
      el.innerHTML = dropdownitem;
    } else if (droppedid == "carousel-item") {
      $(el).attr("id", "single-item-" + idnum);
      idnum++;
      var dividA = "single-item-" + idnum;
      idnum++;
      var olidA = "single-item-" + idnum;
      idnum++;
      var liidA = "single-item-" + idnum;
      idnum++;
      var liidB = "single-item-" + idnum;
      idnum++;
      var liidC = "single-item-" + idnum;
      idnum++;

      var dividB = "single-item-" + idnum;
      idnum++;
      var dividC = "single-item-" + idnum;
      idnum++;
      var dividD = "single-item-" + idnum;
      idnum++;
      var dividE = "single-item-" + idnum;
      idnum++;
      var imgidA = "single-item-" + idnum;
      idnum++;
      var imgidB = "single-item-" + idnum;
      idnum++;
      var imgidC = "single-item-" + idnum;
      idnum++;

      var aidA = "single-item-" + idnum;
      idnum++;
      var spanidA = "single-item-" + idnum;
      idnum++;
      var spanidB = "single-item-" + idnum;
      idnum++;
      var spanidC = "single-item-" + idnum;
      idnum++;
      var spanidD = "single-item-" + idnum;
      idnum++;
      var aidB = "single-item-" + idnum;
      idnum++;

      var carouselitem = `<div id="` + dividA + `" class="carousel slide" data-ride="carousel">
                        <ol id="` + olidA + `" class="carousel-indicators">
                          <li id="` + liidA + `" data-target="#` + dividA + `" data-slide-to="0" class="active"></li>
                          <li id="` + liidB + `" data-target="#` + dividA + `" data-slide-to="1"></li>
                          <li id="` + liidC + `" data-target="#` + dividA + `" data-slide-to="2"></li>
                        </ol>
                        <div id="` + dividB + `" class="carousel-inner">
                          <div id="` + dividC + `" class="carousel-item active">
                            <img id="` + imgidA + `" src="https://via.placeholder.com/500" class="d-block w-100" alt="..." />
                          </div>
                          <div id="` + dividC + `" class="carousel-item">
                            <img id="` + imgidB + `" src="https://via.placeholder.com/500" class="d-block w-100" alt="..." />
                          </div>
                          <div id="` + dividD + `" class="carousel-item">
                            <img id="` + imgidC + `" src="https://via.placeholder.com/500" class="d-block w-100" alt="..." />
                          </div>
                        </div>
                        <a id="` + aidA + `" class="carousel-control-prev" href="#` + dividA + `" role="button" data-slide="prev">
                          <span id="` + spanidA + `" class="carousel-control-prev-icon" aria-hidden="true"></span>
                          <span id="` + spanidB + `" class="sr-only">Previous</span>
                        </a>
                        <a id="` + aidB + `" class="carousel-control-next" href="#` + dividA + `" role="button" data-slide="next">
                          <span id="` + spanidC + `" class="carousel-control-next-icon" aria-hidden="true"></span>
                          <span id="` + spanidD + `" class="sr-only">Next</span>
                        </a>
                      </div>`;
      el.innerHTML = carouselitem;
    }

    el.className += " highlight";
    totalitems += 1;
    //Medium Editor
    var elements = document.querySelectorAll(".editable"),
      editor = new MediumEditor(elements);
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
  })
  .on("over", function (el, container) {
    container.className += " ex-over";
  })
  .on("out", function (el, container) {
    container.className = container.className.replace("ex-over", "");
  });

drake.containers.push(document.getElementById("left-copy"));
drake.containers.push(document.getElementById("right-copy"));
drake.containers.push(document.getElementById("drake-container-1"));
drake.containers.push(document.getElementById("drake-container-2"));
drake.containers.push(document.getElementById("drake-container-3"));
drake.containers.push(document.getElementById("drake-container-4"));
drake.containers.push(document.getElementById("drake-container-5"));

//Carousel
drake.containers.push(document.getElementById("SLFC9E"));
drake.containers.push(document.getElementById("1TOFBA"));
drake.containers.push(document.getElementById("ZK2QR5"));
drake.containers.push(document.getElementById("98RHZA"));
drake.containers.push(document.getElementById("FZV3N1"));

//Cover
drake.containers.push(document.getElementById("JJ7LZ9"));
drake.containers.push(document.getElementById("ZZ3J2D"));
drake.containers.push(document.getElementById("NM2JZ7"));

//Product
drake.containers.push(document.getElementById("VXB4J6"));
drake.containers.push(document.getElementById("1QUCSB"));

drake.containers.push(document.getElementById("X456SZ"));
drake.containers.push(document.getElementById("0P8GOW"));

drake.containers.push(document.getElementById("GDN6ZP"));
drake.containers.push(document.getElementById("7VALPS"));

drake.containers.push(document.getElementById("SAQRCP"));
drake.containers.push(document.getElementById("4YJUM4"));

drake.containers.push(document.getElementById("01PMUX"));
drake.containers.push(document.getElementById("GRFILJ"));

drake.containers.push(document.getElementById("FC4OHH"));
drake.containers.push(document.getElementById("MXG4CB"));
drake.containers.push(document.getElementById("KAYV5W"));
drake.containers.push(document.getElementById("YTQ91F"));
drake.containers.push(document.getElementById("5B5V0T"));
drake.containers.push(document.getElementById("BV99WG"));

//Checkout
drake.containers.push(document.getElementById("I2LQ3C"));
drake.containers.push(document.getElementById("DJQ1CP"));
drake.containers.push(document.getElementById("ODYW1J"));
drake.containers.push(document.getElementById("1QYB74"));

//Shipping
drake.containers.push(document.getElementById("RKFQUD"));
drake.containers.push(document.getElementById("I2LQ3C"));
drake.containers.push(document.getElementById("2K97W0"));
drake.containers.push(document.getElementById("ODYW1J"));
drake.containers.push(document.getElementById("DJQ1CP"));
drake.containers.push(document.getElementById("VD4CYG"));
drake.containers.push(document.getElementById("ESZQCS"));

//Pricing
drake.containers.push(document.getElementById("YLCSVA"));
drake.containers.push(document.getElementById("E3LO4H"));
drake.containers.push(document.getElementById("SQPP2J"));
drake.containers.push(document.getElementById("HIWKBF"));
drake.containers.push(document.getElementById("78OCXQ"));
drake.containers.push(document.getElementById("LRQ475"));
drake.containers.push(document.getElementById("SODKH8"));
drake.containers.push(document.getElementById("GK3GU4"));
drake.containers.push(document.getElementById("B40V2V"));
drake.containers.push(document.getElementById("S41ODD"));
drake.containers.push(document.getElementById("U9YKCO"));

//Login
drake.containers.push(document.getElementById("JUMB123"));
drake.containers.push(document.getElementById("OFS2RX"));

function callUpdate() {
  var result = $.fn.getCleanCode();

  //calling async obj

  (async function () {
    await CefSharp.BindObjectAsync("getHTMLfromjs");

    //The default is to camel case method names (the first letter of the method name is changed to lowercase)
    getHTMLfromjs.updateChange("false");
    getHTMLfromjs.updateHTMLBox(result);
  })();
}
$.fn.getCleanCode = function () {
  var html = $("#right-copy")[0].innerHTML.toString();
  $(".myhtml").html(html);

  //stating the removing
  //removing class of highlight
  $(".myhtml")
    .find(".highlight")
    .each(function () {
      $(this).css("border", "");
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
    .each(function () {
      $(this).css("border", "");
      $(this).removeClass("clickedItem");
    });

  //removing attributes that are unnecessary
  $(".myhtml > *").filter(function () {
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
      var tempID = $(this).attr("id");
      var idcheck = tempID.match(/((single-([A-z]+))(-?)(\d)*)|([A-z0-9]){6}/);
      if (!idcheck) {
        var randnum = "single-item-" + idnum;
        $(this).attr("id", randnum);
      }
    } else {
      var randnum = "single-item-" + idnum;
      $(this).attr("id", randnum);
    }
  });
  //removing medium api classes and attributes
  $(".myhtml")
    .find(".editable")
    .each(function () {
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


  $(".myhtml")
    .find("*")
    .each(function () {
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


  /*$(".myhtml").each(function () {
    if (
      $(this).attr("contenteditable") ||
      $(this).attr("spellcheck") ||
      $(this).attr("data-medium-editor-element") ||
      $(this).attr("role") ||
      $(this).attr("aria-multiline") ||
      $(this).attr("data-medium-editor-editor-index") ||
      $(this).attr("medium-editor-index") ||
      $(this).attr("data-placeholder") ||
      $(this).attr("data-medium-focused") ||
      $(this).attr("style")
    ) {
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
    }
  });*/
  var html = $(".myhtml").html();
  console.log("==================== TIDY HTML5 =======================");
  console.log(html);
  //using tidy.js for html5 formatting
  options = {
    indent: "auto",
    "indent-spaces": 2,
    wrap: 80,
    // markup: true,=
    "tidy-mark": false,
    "input-xml": true,
    doctype: "omit",
  };

  var html = $(".myhtml").html();
  console.log("==================== BEF TIDY HTML5 =======================");
  console.log(html);
  html =
    `<html id="single-item-html">
  <head id="single-item-head">
  <title id="single-item-title">My Website</title>
  <link id="single-item-link1" rel="stylesheet" href="bootstrap/css/bootstrap.min.css" />
  <link id="single-item-link2" rel="stylesheet" href="main.css" />
  </head>
  <body id="single-item-body">` +
    html +
    `
    
</body><script src="bootstrap/js/jquery-3.4.1.slim.min.js" id="single-item-script1"></script>
<script src="bootstrap/js/popper.min.js" id="single-item-script2"></script>
<script src="bootstrap/js/bootstrap.min.js" id="single-item-script3"></script></html>`;

  var result = tidy_html5(html, options);
  //console.log("==================== aft TIDY HTML5 =======================");
  //console.log(result);

  var tagCheck = singleTagCheck(result);

  result = tidy_html5(tagCheck, options);
  $(".myhtml").empty();

  return result;
};

function testFunc(myvar) {
  var csharpHTML = myvar;
  //taking string between body and script/</body
  var editedhtml = csharpHTML.match(
    '(body"|body( )*|<( )*body (.)*()*)>((.|[\r\n])*?)<( )*(script|/( )*body)'
  );
  //var editedhtml = csharpHTML;
  console.log(editedhtml);

  editedhtml = editedhtml[6];
  console.log(editedhtml);

  $("#right-copy").html(editedhtml);

  $("#right-copy")
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
  });

  var result = $.fn.getCleanCode();
  (async function () {
    await CefSharp.BindObjectAsync("getHTMLfromjs");
 
    //The default is to camel case method names (the first letter of the method name is changed to lowercase)
    getHTMLfromjs.updateChange("false");
 
    getHTMLfromjs.updateHTMLBox(result);
  })();

  //updating the div
  /*var result = $.fn.getCleanCode();

  //calling async obj
  (async function () {
    await CefSharp.BindObjectAsync("getHTMLfromjs");

    //The default is to camel case method names (the first letter of the method name is changed to lowercase)
    getHTMLfromjs.updateChange("false");
    getHTMLfromjs.updateHTMLBox(result);
  })();*/
}

/*function randomId() {
  var randnum =
    "single-item-" + Math.floor(100000 + Math.random() * 900000).toString();
  while ($("#" + randnum).length) {
    randnum =
      "single-item-" + Math.floor(100000 + Math.random() * 900000).toString();
  }
  return randnum;
}*/

//Preventing any kind of form from submitting
$("#right-copy form").submit(function (e) {
  e.preventDefault();
});

function singleTagCheck(text) {
  var str = text;

  var regex = RegExp(
    /(<(img|br|hr|area|base|col|embed|input|link|meta|param|source|track|wbr)([^<])*>)/g
  );
  var regex2 = RegExp(
    /(<(img|br|hr|area|base|col|embed|input|link|meta|param|source|track|wbr)([^<])*\/>)/
  );
  var startInd = 0;
  var editstr = "";
  var editedString = "";
  while ((str2 = regex.exec(str))) {
    if (str2[0].match(regex2) == null) {
      editstr = str2[0].substring(0, str2[0].length - 1) + " />";
      editedString += str.substring(startInd, str2["index"]) + editstr;
      startInd = str2["index"] + str2[0].length;
    }
    //console.log(str2);
  }
  editedString += str.substring(startInd, str.length);
  console.log(
    "======================================================================="
  );
  console.log(editedString);
  console.log(
    "======================================================================="
  );
  return editedString;
}