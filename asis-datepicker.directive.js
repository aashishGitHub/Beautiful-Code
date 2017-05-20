// ReSharper disable InconsistentNaming
(function () {
    'use strict';
    angular.module('asis.directives')
        .directive('datepicker',
            function() {
                return {
                    restrict: 'A',
                    require: 'ngModel',
                    link: function(scope, element, attrs, ctrl) {                        
                        if (attrs["datepicker"] !== "false") {
                            var options = attrs["datepickerOptions"]
                                ? $.parseJSON(attrs["datepickerOptions"])
                                : { constrainInput: true };

                            if (attrs.Disable) {
                                $(element).on("keydown contextmenu cut copy paste", function (e) {
                                    debugger; if (e.keyCode!== 8 && e.keyCode!==46) {
                                        e.preventDefault();
                                    }
                                    }
                                })
                                //element
                            }
                            element.datepicker({
                                constrainInput: options.constrainInput,
                                timeFormat: $.asis.displayTimeFormat().replace('tt', 'TT'),
                                onSelect: function(date) {
                                    ctrl.$setViewValue(date);
                                    ctrl.$commitViewValue();

                                    var $element = $(element);
                                    var format = $element.datepicker('option', 'dateFormat');
                                    var date = $element.datepicker({ dateFormat: format }).val();
                                    var $target;
                                    var oldValue;
                                    if (attrs.minDateOf) {
                                        $target = $('#' + attrs.minDateOf);
                                      
                                        oldValue = $target.val();                                       
                                        $target.datepicker('option', 'minDate', date);
                                        if (oldValue && (new Date(oldValue) < new Date(date))) {
                                            $target.val(date);
                                        } else $target.val(oldValue);
                                        $target.trigger('change');
                                    }
                                    if (attrs.maxDateOf) {
                                        $target = $('#' + attrs.maxDateOf);
                                        oldValue = $target.val();
                                        $target.datepicker('option', 'maxDate', date);
                                        $target.val(oldValue);
                                        $target.trigger('change');
                                    }                                   
                                    element.off("focus").datepicker("hide");
                                    scope.$apply();

                                    //Trigger change event when the date is updated, for the handlers to process
                                    element.trigger('change');
                                }
                            }).on('click', function () {
                                element.datepicker("show");
                            });
                            //The above change is to address the IE datepicker issue of not closing
                            //when the date andor time selected or closed
                        }
                    }
                };
            });
}());
// ReSharper restore InconsistentNaming
