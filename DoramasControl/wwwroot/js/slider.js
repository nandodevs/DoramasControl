sliderFunction();

function sliderFunction() {
    // Adiciona o efeito "hover" nas imagens
    const imagens = document.querySelectorAll(".imagem img");
    imagens.forEach((imagem) => {
        imagem.addEventListener("mouseenter", () => {
            imagem.style.opacity = 0.8;
        });
        imagem.addEventListener("mouseleave", () => {
            imagem.style.opacity = 1;
        });
    });
}
