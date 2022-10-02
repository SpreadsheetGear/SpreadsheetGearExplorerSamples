function showPageOverlay(content) {
    $("#page-overlay")
    .fadeIn(100)
    .css("display", "block")
    .append(content);
  $(document).on('keydown', pageOverlayKeyDown);
}

function hidePageOverlay() {
  $("#page-overlay")
    .fadeOut(100)
    .html("");
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

$(function () {
    let whiteList = $.fn.tooltip.Constructor.Default.whiteList
    whiteList.span = ["style", "class"];
    whiteList.div = ["style", "class"];
  $('[data-toggle="tooltip"]').tooltip();
});