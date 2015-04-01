$(document).ready(function () {
	$(".header").click(function (evt) {
		var sortfield = $(evt.target).data("sortfield");
		if ($("#SortField").val() == sortfield) {
			if ($("#SortDirection").val() == "ascending") {
				$("#SortDirection").val("descending");
			}
			else {
				$("#SortDirection").val("ascending");
			}
		}
		else {
			$("#SortField").val(sortfield);
			$("#SortDirection").val("ascending");
		}
		evt.preventDefault();
		$("form").submit();
	});
});