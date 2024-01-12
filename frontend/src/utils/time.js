export const dateFormat = (time) => {
    return new Intl.DateTimeFormat("ru", {dateStyle:"short"}).format(time);
}
export const dateTimeFormat = (time) => {
    return new Intl.DateTimeFormat("ru", {dateStyle:"short", timeStyle:"short"}).format(time);
}
