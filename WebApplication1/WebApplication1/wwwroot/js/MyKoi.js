function openAddModal() {
    document.getElementById("productAddModal").style.display = "flex";
}

function closeAddModal() {
    document.getElementById("productAddModal").style.display = "none";
}

function filterKoiList() {
    const searchValue = document.getElementById("searchBar").value.toLowerCase();
    const rows = document.querySelectorAll("#koiTableBody tr");
    rows.forEach(row => {
        const nameCell = row.querySelector("td:nth-child(2)");
        if (nameCell && nameCell.textContent.toLowerCase().includes(searchValue)) {
            row.style.display = "";
        } else {
            row.style.display = "none";
        }
    });
}