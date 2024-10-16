const sidebar = document.getElementById('sidebar');
const toggleBtn = document.getElementById('open-btn');
const closeBtn = document.getElementById('close-btn');
const mainContent = document.getElementById('mainContent');

// Função para abrir a sidebar
toggleBtn.onclick = function () {
    sidebar.classList.toggle('open'); // Alterna a classe 'open'
    mainContent.classList.toggle('shift'); // Move o conteúdo principal
}

// Função para fechar a sidebar
closeBtn.onclick = function () {
    sidebar.classList.remove('open');
    mainContent.classList.remove('shift');
}