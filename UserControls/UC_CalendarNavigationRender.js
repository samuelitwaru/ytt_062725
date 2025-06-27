function UC_CalendarNavigation($) {
	  
	  

	var template = '<div></div>';
	var partials = {  }; 
	Mustache.parse(template);
	var _iOnNavigationClicked = 0; 
	var $container;
	this.show = function() {
			$container = $(this.getContainerControl());

			// Raise before show scripts

			_iOnNavigationClicked = 0; 

			//if (this.IsPostBack)
				this.setHtml(Mustache.render(template, this, partials));
			this.renderChildContainers();

			$(this.getContainerControl())
				.find("[data-event='NavigationClicked']")
				.on('navigationclicked', this.onNavigationClickedHandler.closure(this))
				.each(function (i) {
					this.setAttribute("data-items-index", i + 1);
				}); 

			// Raise after show scripts
			this.Start(); 
	}

	this.Scripts = [];

		this.Start = function() {

					const UC = this
					
					const monthSelect = $('.monthselect')
					const yearSelect = $('.yearselect')
					
					function addEventListeners () {
						$(document).on('click', '.prev.available', function() {
							const month = parseInt($('.monthselect')[0].value)
							const year = parseInt($('.yearselect')[0].value)
							UC.selectedYear = year
							UC.selectedMonth = month
							UC.NavigationClicked()
						});
					
						$(document).on('click', '.next.available', function() {
							const month = parseInt($('.monthselect')[0].value)
							const year = parseInt($('.yearselect')[0].value)
							UC.selectedYear = year
							UC.selectedMonth = month
							UC.NavigationClicked()
						});
						
					}
					
					$(document).ready(function() {
						console.log('Document is ready!');
						addEventListeners()
					});
					
				
		}


		this.onNavigationClickedHandler = function (e) {
			if (e) {
				var target = e.currentTarget;
				e.preventDefault();
				 
				 
			}

			if (this.NavigationClicked) {
				this.NavigationClicked();
			}
		} 

	this.autoToggleVisibility = true;

	var childContainers = {};
	this.renderChildContainers = function () {
		$container
			.find("[data-slot][data-parent='" + this.ContainerName + "']")
			.each((function (i, slot) {
				var $slot = $(slot),
					slotName = $slot.attr('data-slot'),
					slotContentEl;

				slotContentEl = childContainers[slotName];
				if (!slotContentEl) {				
					slotContentEl = this.getChildContainer(slotName)
					childContainers[slotName] = slotContentEl;
					slotContentEl.parentNode.removeChild(slotContentEl);
				}
				$slot.append(slotContentEl);
				$(slotContentEl).show();
			}).closure(this));
	};

}