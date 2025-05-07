export function isTextClamped(elementId) {
    const element = document.getElementById(elementId);
    if (!element) return false;

    return element.scrollHeight > element.clientHeight;
}

export function observeTextClamping(elementId, dotnetHelper) {
    const element = document.getElementById(elementId);
    if (!element) return;

    const observer = new ResizeObserver(() => {
        const isClamped = element.scrollHeight > element.clientHeight;
        dotnetHelper.invokeMethodAsync('UpdateClampedState', elementId, isClamped);
    });

    observer.observe(element);
    return {
        dispose: () => observer.disconnect()
    };
}