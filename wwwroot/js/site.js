document.querySelectorAll(".infoEmployee").forEach(row => {
    row.addEventListener("click", function () {
        window.location.href = this.dataset.url;
        })
})


