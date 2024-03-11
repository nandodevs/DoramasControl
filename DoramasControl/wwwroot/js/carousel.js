document.addEventListener('DOMContentLoaded', function () {
    const carousel = document.querySelector('.carousel');
    const apiUrl = 'https://mdl-fsx2hvaj2-nandodevs.vercel.app/api/top-dramas';

    // Fetch data from API
    fetch(apiUrl)
        .then(response => response.json())
        .then(data => {
            // Create carousel items dynamically
            data.forEach(drama => {
                const item = createCarouselItem(drama);
                carousel.appendChild(item);
            });

            // Duplicate items for smoother carousel effect
            const items = document.querySelectorAll('.carousel-item');
            items.forEach(item => {
                const clone = item.cloneNode(true);
                carousel.appendChild(clone);
            });

            // Set initial transform to center the first set of items
            carousel.style.transform = 'translateX(-50%)';
        });

    // Function to create a carousel item
    function createCarouselItem(drama) {
        const item = document.createElement('div');
        item.classList.add('carousel-item');

        const image = document.createElement('img');
        image.src = drama.Imagem;
        image.alt = drama.Título;

        const title = document.createElement('div');
        title.classList.add('carousel-title');
        title.textContent = drama.Título;

        const rating = document.createElement('div');
        rating.classList.add('carousel-rating');
        rating.textContent = `Classificação: ${drama.Classificação}`;

        item.appendChild(image);
        item.appendChild(title);
        item.appendChild(rating);

        return item;
    }
});
