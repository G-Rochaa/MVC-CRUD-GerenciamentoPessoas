﻿
jQuery.noConflict();
(function ($) {
    $(document).ready(function () {
        $('.tabela-pessoas').DataTable(
            {
                language: {
                    url: '//cdn.datatables.net/plug-ins/2.3.2/i18n/pt-BR.json',
                }
            }
        );
    })
})(jQuery);