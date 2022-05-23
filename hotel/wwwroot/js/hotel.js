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


