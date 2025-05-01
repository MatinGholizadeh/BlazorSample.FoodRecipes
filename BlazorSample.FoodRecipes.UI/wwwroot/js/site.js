window.checkTextOverflow = (container, element) => {
    return element.scrollWidth > container.clientWidth;
};

window.addScrollClass = (element) => {
    element.classList.add('scrollable');
};