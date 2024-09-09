// formHandler.js

document.addEventListener('DOMContentLoaded', function () {
    const treatmentSelect = document.getElementById('inputTreatment');
    const sections = {
        'Indoor': document.getElementById('indoorSection'),
        'Outdoor': document.getElementById('outdoorSection'),
        'Prolong': document.getElementById('prolongSection')
    };

    function calculateTotalCharges() {
        let totalCharges = 0;

        const treatment = treatmentSelect.value;

        if (treatment === 'Indoor') {
            totalCharges += parseFloat(document.getElementById('inputConsultationFeeIndoor').value) || 0;
            totalCharges += parseFloat(document.getElementById('inputPharmacyChargesIndoor').value) || 0;
            totalCharges += parseFloat(document.getElementById('inputInvestigationIndoor').value) || 0;
        } else if (treatment === 'Outdoor') {
            totalCharges += parseFloat(document.getElementById('inputConsultationFeeOutdoor').value) || 0;
            totalCharges += parseFloat(document.getElementById('inputInvestigationOutdoor').value) || 0;
        } else if (treatment === 'Prolong') {
            totalCharges += parseFloat(document.getElementById('inputConsultationFeeProlong').value) || 0;
            totalCharges += parseFloat(document.getElementById('inputPharmacyChargesProlong').value) || 0;
        }

        document.getElementById('outputTotalCharges').value = totalCharges.toFixed(0);
    }

    function updateForm() {
        Object.values(sections).forEach(section => section.style.display = 'none');

        const treatment = treatmentSelect.value;
        if (sections[treatment]) {
            sections[treatment].style.display = 'block';
        }

        calculateTotalCharges();
    }

    treatmentSelect.addEventListener('change', updateForm);

    // Attach input event listeners for calculating charges
    document.querySelectorAll('.form-control').forEach(input => {
        input.addEventListener('input', calculateTotalCharges);
    });
});
