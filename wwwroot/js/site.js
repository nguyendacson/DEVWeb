document.querySelectorAll(".infoEmployee").forEach(row => {
    row.addEventListener("click", function () {
        window.location.href = this.dataset.url;
        })
})

const baseSalaryInput = document.querySelector(`[name = "SalaryInputVM.BaseSalary"]`);
const bonusSalaryInput = document.querySelector(`[name = "SalaryInputVM.Bonus"]`);
const submit = document.getElementById("submitSalary");
const formSalary = document.getElementById("salaryForm");

function validateSalary() {
    const baseSalary = baseSalaryInput.value.trim();
    const bonusSalary = bonusSalaryInput.value.trim();

    const isValid =
        baseSalary !== "" &&
        !isNaN(Number(baseSalary)) &&
        (bonusSalary === "" || !isNaN(Number(bonusSalary)));

    submit.disabled = !isValid;

    if (isValid) {
        submit.classList.remove("btn-secondary");
        submit.classList.add("btn-primary");
    } else {
        submit.classList.remove("btn-primary");
        submit.classList.add("btn-secondary");
    }

    return isValid; 
}

baseSalaryInput.addEventListener("input", validateSalary);
bonusSalaryInput.addEventListener("input", validateSalary);

//formSalary.addEventListener("submit", function (event) {
//    if (!validateSalary()) {
//        event.preventDefault();
//        alert("Please enter valid numeric values for Base Salary and Bonus.");
//    }
//});

validateSalary();

