function scrollLeft() {
    const container = document.querySelector('.actor-container');
    container.scrollBy({ left: -300, behavior: 'smooth' });
}

function scrollRight() {
    const container = document.querySelector('.actor-container');
    container.scrollBy({ left: 300, behavior: 'smooth' });
}
document.getElementById('scrollLeftButton').addEventListener('click', scrollLeft);
document.getElementById('scrollRightButton').addEventListener('click', scrollRight);