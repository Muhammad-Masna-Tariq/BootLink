function popupfunc(question) {
  var question = prompt(question, "");
  if (question == null || question == "") {
    e.preventDefault();
  } else {
    return question;
  }
}
