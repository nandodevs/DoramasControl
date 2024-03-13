document.addEventListener("DOMContentLoaded", function () {
    var images = [
        "url('~/images/imagem1.jpg')",
        "url('~/images/imagem2.jpg')",
        "url('~/images/imagem3.jpg')"
    ];
    var index = 0;

    function changeBackgroundImage() {
        index = (index + 1) % images.length;
        document.querySelector('.background-image-slider').style.backgroundImage = images[index];
    }

    setInterval(changeBackgroundImage, 5000); // Mude de imagem a cada 5 segundos (5000 milissegundos)
});
