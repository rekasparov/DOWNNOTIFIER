$(() => {
    init = () => {
        var applicationList = $('.card');
        for (var index = 0; index < applicationList.length; index++) {
            doWork(applicationList[index]);
        }
    };

    doWork = (application) => {
        debugger;
        var intervalTime = parseInt($(application).data("interval-time")) * 1000;
        var url = $(application).data("url");

        var lastRequestTime = $(application).find('.last-request-time')[0];
        var applicationStatus = $(application).find('.application-status')[0];

        setInterval(() => {
            $.ajax({
                url: url,
                method: 'GET',
                beforeSend: () => {
                    $(applicationStatus).html('Sorgulanıyor...');
                },
                success: (x, y) => {
                    $(applicationStatus).html('Online');
                },
                error: (x, y) => {
                    $(applicationStatus).html(x.state());
                },
                complete: () => {
                    var currenctDate = new Date();

                    var now = currenctDate.getDay() + '.' +
                        currenctDate.getMonth() + '.' +
                        currenctDate.getFullYear() + ' ' +
                        currenctDate.getHours() + ':' +
                        currenctDate.getMinutes() + ':' +
                        currenctDate.getSeconds();

                    $(lastRequestTime).html(now);
                },
                async: true
            })
        }, intervalTime);
    };

    init();
});