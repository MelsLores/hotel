var rating=0;

let star = document.querySelectorAll('input');

for (let i = 0; i < star.length; i++) {
	star[i].addEventListener('click', function () {
		i = this.value;
		console.log("entro");
		document.querySelector('#val').value =i;
		rating = i;
	});
}
var aux = null;
$("#select_rooms").change(function () {
	console.log("hola");
	console.log(this);
	aux = this;
	$("#ttl").text('Total: $' + this.value.split("-")[1]);

});

$(".modal").modal("show");


