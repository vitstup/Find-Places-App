let currentId = 0;
let carouseleList = null;
let itemWidth = 0;

let autoCarouselEnabled = false;
let autoCarouselScrollInterval = 3000;

function initCarousel() {
    autoCarouselEnabled = true;

    currentId = 0;

    carouseleList = document.querySelector('.carouselList');

    itemWidth = carouseleList.offsetWidth;

    autoCarousel();
}

function scrollLeft() {
    console.log("Left");

    currentId--;

    if (currentId < 0) {
        currentId = carouseleList.childElementCount - 1;
    }

    move();
}

function scrollRight() {
    console.log("Right");

    currentId++;

    if (currentId >= carouseleList.childElementCount) {
        currentId = 0;
    }

    move();
}

function move() {
    carouseleList.style.marginLeft = -(itemWidth * currentId) + "px";
}

async function autoCarousel() {
    while (autoCarouselEnabled) {
        await new Promise(resolve => setTimeout(resolve, autoCarouselScrollInterval));

        if (!autoCarouselEnabled) return;

        console.log("Carousel swaped automatically");

        scrollRight();
    }
}

function stopCarousel() {
    autoCarouselEnabled = false;
}