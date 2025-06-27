function UC_SetWeekTableHeaders($) {
	  
	  

	var template = '<UC_SetWeekTableHeaders>';
	var partials = {  }; 
	Mustache.parse(template);
	var $container;
	this.show = function() {
			$container = $(this.getContainerControl());

			// Raise before show scripts


			//if (this.IsPostBack)
				this.setHtml(Mustache.render(template, this, partials));
			this.renderChildContainers();



			// Raise after show scripts
			this.Start(); 
	}

	this.Scripts = [];

		this.Start = function() {

					try {
						this.formatDate = function (date) {
							const options = { weekday: 'short' }; // e.g., Mon, Tue
							const weekday = date.toLocaleDateString('en-US', options);
							const day = String(date.getDate()).padStart(2, '0'); // Zero-padded day
							return `${weekday} ${day}`;
						}
					
						const UC = this
						const headers = document.querySelectorAll("#GridContainerTbl th.WeekDay span");
						
						let count = 0;
						
						const fromDate = new Date(this.fromDate);
						const toDate = new Date(this.toDate);
						while (fromDate <= toDate) {
							const html = this.formatDate(fromDate);
							headers[count].innerHTML = html;
							fromDate.setDate(fromDate.getDate() + 1);
							count += 1;
						}
					} catch (e){
						console.error(e)
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