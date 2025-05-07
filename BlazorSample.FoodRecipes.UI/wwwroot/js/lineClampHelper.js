window.checkOverflow = (element) => {
    const lineHeight = parseFloat(getComputedStyle(element).lineHeight);
    const maxLines = 2;
    const maxHeight = lineHeight * maxLines;
    return element.scrollHeight > maxHeight;
}

