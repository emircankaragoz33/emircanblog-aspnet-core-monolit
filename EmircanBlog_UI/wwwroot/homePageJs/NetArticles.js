 document.addEventListener('DOMContentLoaded', function () {
        var tabLinks = document.querySelectorAll('.tm-tab-link');

        tabLinks.forEach(function (tabLink) {
            tabLink.addEventListener('click', function (event) {
                event.preventDefault();

                // Aktif sekme belirleyici
                var tabId = this.getAttribute('data-id');

                if (tabId === 'cold') {
                    var xhr = new XMLHttpRequest();
                    xhr.open('GET', '/Home/GetArticles', true);

                    xhr.onload = function () {
                        if (xhr.status >= 200 && xhr.status < 300) {
                            var data = JSON.parse(xhr.responseText);
                            var articlesContainer = document.getElementById('cold');
                            articlesContainer.innerHTML = ''; // Önceki içerikleri temizleyin

                            data.forEach(function (article) {
                                var articleDiv = document.createElement('div');
                                articleDiv.className = 'tm-list-item';
                                articleDiv.innerHTML = `
                                                                                 <img src="net.png" alt="Image" class="tm-list-item-img">
                                        <div class="tm-black-bg tm-list-item-text">

                                                            <h3 class="tm-list-item-name">${article.title} <span class="tm-list-item-price">${article.createdDate}</span> </h3>
                                            <p class="tm-list-item-description">${article.content}</p>
                                        </div>
                                    `;
                                articlesContainer.appendChild(articleDiv);
                            });
                        } else {
                            console.error('Veri alırken bir hata oluştu:', xhr.statusText);
                        }
                    };

                    xhr.onerror = function () {
                        console.error('Bağlantı hatası');
                    };

                    xhr.send();
                } else {
                    // Diğer sekmelerin işlenmesi
                }

                openTab(event, tabId);
            });
        });
    });

    function openTab(evt, id) {
        var contents = document.querySelectorAll('.tm-tab-content');
        contents.forEach(function (content) {
            content.style.display = 'none';
        });

        var activeContent = document.getElementById(id);
        if (activeContent) {
            activeContent.style.display = 'block';
        }

        var tabLinks = document.querySelectorAll('.tm-tab-link');
        tabLinks.forEach(function (link) {
            link.classList.remove('active');
        });

        evt.currentTarget.classList.add('active');
    }