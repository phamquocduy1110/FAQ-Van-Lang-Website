// JQUERY
$(function () {
	var images = [
		"https://miro.medium.com/max/2400/1*G173aDBoFqhQcC9pqUKthg.jpeg",
		"https://miro.medium.com/max/2400/1*G173aDBoFqhQcC9pqUKthg.jpeg"
	];

	$("#container").append(
		"<style>#container, .acceptContainer:before, #logoContainer:before {background: url(" +
		images[Math.floor(Math.random() * images.length)] +
		") center fixed }"
	);

	setTimeout(function () {
		$(".logoContainer").transition({ scale: 1 }, 700, "ease");
		setTimeout(function () {
			$(".logoContainer .logo").addClass("loadIn");
			setTimeout(function () {
				$(".logoContainer .text").addClass("loadIn");
				setTimeout(function () {
					$(".acceptContainer").transition({ height: "431.5px" });
					setTimeout(function () {
						$(".acceptContainer").addClass("loadIn");
						setTimeout(function () {
							$(".formDiv, form h1").addClass("loadIn");
						}, 500);
					}, 500);
				}, 500);
			}, 500);
		}, 1000);
	}, 10);
});