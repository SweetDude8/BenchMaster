// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

document.addEventListener("DOMContentLoaded", () => {

    if (location.href.toLowerCase().endsWith("home")) {
        document.getElementById("max_bench_weight").addEventListener("keyup", (e) => {
            let errorSpan = e.srcElement.parentElement.querySelector(".error_span");
            if (errorSpan) {
                errorSpan.style.display = "none";
            }
        })

        document.getElementById("weekly_increment").addEventListener("keyup", (e) => {
            let errorSpan = e.srcElement.parentElement.querySelector(".error_span");
            if (errorSpan) {
                errorSpan.style.display = "none";
            }
        })

        document.getElementById("submitBtn").addEventListener("click", (e) => {
            let maxBenchWeightInputElement = document.getElementById("max_bench_weight");
            let incrementInputElement = document.getElementById("weekly_increment");
            let formHasErrors = false;

            if (checkForValidNumber(maxBenchWeightInputElement.value)) {
                addErrorSpanToElement(maxBenchWeightInputElement.parentElement);
                formHasErrors = true;
            }

            if (checkForValidNumber(incrementInputElement.value)) {
                addErrorSpanToElement(incrementInputElement.parentElement);
                formHasErrors = true;
            }

            if (formHasErrors) {
                e.preventDefault();
            }
        })
    }
});

function checkForValidNumber(number) {
    //@"^[0-9]+(,[0-9]+)?|[0-9]+(\.[0-9]+)?$"
    //let regex = /^\d+(\.\d+)?$/;
    //return regex.test(number);

    return !parseFloat(number) > 0;
}

function addErrorSpanToElement(element) {
    let existingErrorSpan = element.querySelector(".error_span");
    if (existingErrorSpan) {

        if (existingErrorSpan.style.display === "none") {
            existingErrorSpan.style.display = "block";
        } 
        return;
    }

    let errorSpan = document.createElement("span");
    errorSpan.textContent = "Enter a valid number";
    errorSpan.style.color = "red";
    errorSpan.className = "error_span";
    element.appendChild(errorSpan);
}