window.checkSingleDescription = (dotNetRef, id) => {
    setTimeout(() => {
        const el = document.getElementById(`desc-${id}`);
        if (el) {
            const lineHeight = parseFloat(getComputedStyle(el).lineHeight);
            const maxLines = 2;
            const maxHeight = lineHeight * maxLines;
            const isOverflow = el.scrollHeight > maxHeight;
            dotNetRef.invokeMethodAsync("SetShowMore", isOverflow);
        }
    }, 50);
};