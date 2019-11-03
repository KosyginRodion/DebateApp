$(function () {
	$('#dateRegistration').datetimepicker({
		format: 'DD.MM.YYYY',
		locale: 'ru'
	});

	$('#timeRegistration').datetimepicker({
		format: 'HH:mm',
		locale: 'ru'
	});

	//var persons = ["Родя", "Катя"];
	//$('#player2').autocomplete({
	//	source: persons,
	//	minLength: 2,
	//});
});
