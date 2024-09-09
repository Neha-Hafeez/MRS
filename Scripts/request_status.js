// JavaScript to handle modal data population and form submission
document.addEventListener("DOMContentLoaded", function () {
    // Handle Details button click
    document.querySelectorAll(".details-button").forEach(function (button) {
        button.addEventListener("click", function () {
            const id = this.getAttribute("data-id");
            // Fetch and populate request details based on ID
            // Simulating with static data for demonstration
            document.getElementById("employeeName").innerText = "John Smith";
            document.getElementById("patientName").innerText = "Jane Smith";
            document.getElementById("relation").innerText = "Spouse";
            document.getElementById("requestDate").innerText = "2024-09-01";
            document.getElementById("amountRequested").innerText = "$500";
            document.getElementById("remarks").innerText = "Request for medical reimbursement.";
        });
    });

    // Handle Forward button click
    document.querySelectorAll(".forward-button").forEach(function (button) {
        button.addEventListener("click", function () {
            const id = this.getAttribute("data-id");
            document.getElementById("requestIdToForward").value = id;
            // Open the forward request modal
            $("#forwardRequestModal").modal("show");
        });
    });
    // Handle Reject button click
    document.querySelectorAll(".reject-button").forEach(function (button) {
        button.addEventListener("click", function () {
            const id = this.getAttribute("data-id");
            document.getElementById("requestIdToReject").value = id;
        });
    });
    // Handle Forward Request form submission
    document.getElementById("forwardRequestForm").addEventListener("submit", function (event) {
        event.preventDefault();
        const requestId = document.getElementById("requestIdToForward").value;
        const forwardTo = document.getElementById("forwardTo").value;
        const remarks = document.getElementById("forwardRemarks").value;

        // Handle the form submission to forward the request
        // For demonstration purposes, we'll log the data
        console.log(`Forwarding Request ID ${requestId} to ${forwardTo} with remarks: ${remarks}`);

        // Close the modal
        $("#forwardRequestModal").modal("hide");
    });
    // Handle Reject Request form submission
    document.getElementById("rejectRequestForm").addEventListener("submit", function (event) {
        event.preventDefault();
        const id = document.getElementById("requestIdToReject").value;
        const rejectRemarks = document.getElementById("rejectRemarks").value;
        console.log(`Reject Request ${id} with remarks: ${rejectRemarks}`);
        // Implement form submission logic here
    });
});