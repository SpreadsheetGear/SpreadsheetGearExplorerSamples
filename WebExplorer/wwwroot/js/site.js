function showPageOverlay(content) {
  $("#page-overlay")
    .css("display", "block")
    .append(content);
  $(document).on('keydown', pageOverlayKeyDown);
}

function hidePageOverlay() {
  $("#page-overlay").css("display", "none").html("");
  $(document).off("keydown", pageOverlayKeyDown);
}

function pageOverlayKeyDown(e) {
  if (e.key == "Escape")
    hidePageOverlay();
}

$("#page-overlay").click(function () {
  hidePageOverlay();
});

function appendQueryString(url, varName, varValue) {
  if (url.indexOf('?') >= 0)
    url += "&" + varName + "=" + escape(varValue);
  else
    url += "?" + varName + "=" + escape(varValue);
  return url;
}