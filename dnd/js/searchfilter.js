function searchFilter() {
  var input, filter, ul, li, li2, a, i, txtValue;
  input = document.getElementById("searchTerm");
  filter = input.value.toUpperCase();
  ul = document.getElementById("left-copy");
  li = ul.getElementsByTagName("div");
  console.log(li);
  li2 = ul.getElementsByClassName("unitem");
  for (i = 0; i < li.length; i++) {
    a = li[i].getElementsByTagName("span")[0];
    txtValue = a.textContent || a.innerText;
    if (txtValue.toUpperCase().indexOf(filter) > -1) {
      li[i].style.display = "";
    } else {
      li[i].style.display = "none";
    }
  }
  for (i = 0; i < li2.length; i++) {
    a = li2[i].getElementsByTagName("span")[0];
    txtValue = a.textContent || a.innerText;
    if (txtValue.toUpperCase().indexOf(filter) > -1) {
      li2[i].style.display = "";
    } else {
      li2[i].style.display = "none";
    }
  }
}
