
const row = document.querySelector(".row");
const botoesSeta = document.querySelectorAll(".setas button");

let posicaoAtual = 0;

function setaEsquerda() {
    if (posicaoAtual > 0) {
        posicaoAtual--;
        row.scrollLeft -= 200;
    }
}

function setaDireita() {
    if (posicaoAtual < row.scrollWidth - row.clientWidth) {
        posicaoAtual++;
        row.scrollLeft += 200;
    }
}

botoesSeta.forEach((botao) => {
    botao.addEventListener("click", () => {
        if (botao.classList.contains("seta-esquerda")) {
            setaEsquerda();
        } else {
            setaDireita();
        }
    });
});
