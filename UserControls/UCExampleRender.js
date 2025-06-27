function UCExample($) {

	var template = '<div>	<button  data-event=\"Click\" >Button 1</button>	<button  data-event=\"Click2\" >Button 2</button>		<div class=\"extra content\">       <a> <i class=\"user icon\"></i> {{ExtraContent}} </a>        <div data-slot=\"extraContent\" data-parent=\"{{ContainerName}}\"></div>   </div> </div>';
	var partials = {  }; 
	Mustache.parse(template);
	var _iOnClick = 0; 
	var _iOnClick2 = 0; 
	var $container;
	this.show = function() {
			$container = $(this.getContainerControl());

			// Raise before show scripts

			_iOnClick = 0; 
			_iOnClick2 = 0; 

			//if (this.IsPostBack)
				this.setHtml(Mustache.render(template, this, partials));
			this.renderChildContainers();

			$(this.getContainerControl())
				.find("[data-event='Click']")
				.on('click', this.onClickHandler.closure(this))
				.each(function (i) {
					this.setAttribute("data-items-index", i + 1);
				}); 
			$(this.getContainerControl())
				.find("[data-event='Click2']")
				.on('click2', this.onClick2Handler.closure(this))
				.each(function (i) {
					this.setAttribute("data-items-index", i + 1);
				}); 

			// Raise after show scripts

	}

	this.Scripts = [];



		this.onClickHandler = function (e) {
			if (e) {
				var target = e.currentTarget;
				e.preventDefault();
			}

			if (this.Click) {
				this.Click();
			}
		} 

		this.onClick2Handler = function (e) {
			if (e) {
				var target = e.currentTarget;
				e.preventDefault();
			}

			if (this.Click2) {
				this.Click2();
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