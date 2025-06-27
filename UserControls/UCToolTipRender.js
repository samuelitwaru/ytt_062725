function UCToolTip($) {

	var template = '<div id=\"tooltip\" class=\"tooltip1\">	<span class=\"fa fa-info-circle fa-lg\"></span>  	<span class=\"tooltip1text\">		<strong>Zoom in/out:</strong> Hold Ctrl + Scroll up/down	</span></div>';
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

			  	// change tooltip position to before 'Date Range' Label
			  	var newElement = document.getElementById('tooltip');
			    var targetElement = document.getElementById("TEXTBLOCKDATERANGE_RANGETEXT");
			    var parentElement = targetElement.parentNode;
			    parentElement.insertBefore(newElement, targetElement);
			  
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