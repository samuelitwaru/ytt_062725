function UCVISTimeline($) {
	  
	  
	  
	  
	  
	  
	  
	  
	  
	  
	  
	  

	var template = '<div style=\"display:none\">	{{startDate}}	{{endDate}}	{{item}}</div><br /><div id=\"visualization\" ></div><div id=\"key\" style=\"display:flex; margin-top: 10px\">	<div style=\"display:flex;\">		<div style=\"background: #dddddd; height:10px; width:10px; margin: 4px\"></div> <label>Pending</label>		<div style=\"background: #D5DDF6; height:10px; width:10px; margin: 4px\"></div> <label>Default</label>	</div></div>';
	var partials = {  }; 
	Mustache.parse(template);
	var _iOnClick = 0; 
	var _iOnclick2 = 0; 
	var _iOnDateRangeChanged = 0; 
	var $container;
	this.show = function() {
			$container = $(this.getContainerControl());

			// Raise before show scripts

			_iOnClick = 0; 
			_iOnclick2 = 0; 
			_iOnDateRangeChanged = 0; 

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
				.find("[data-event='click2']")
				.on('click2', this.onclick2Handler.closure(this))
				.each(function (i) {
					this.setAttribute("data-items-index", i + 1);
				}); 
			$(this.getContainerControl())
				.find("[data-event='DateRangeChanged']")
				.on('daterangechanged', this.onDateRangeChangedHandler.closure(this))
				.each(function (i) {
					this.setAttribute("data-items-index", i + 1);
				}); 

			// Raise after show scripts
			this.Init2(); 
	}

	this.Scripts = [];

		this.Init2 = function() {

				
					try {			
						const style = document.createElement('style');
						// append holiday styling
						var styleString = `
							.vis-item.vis-background.holiday {
								background-color: #faf2cc80;
							}
						`
						style.innerHTML = styleString
						document.head.appendChild(style);
						
						function formatDate(date) {
							const year = `${date.getFullYear()}`.slice(-2);
							const month = ('0' + (date.getMonth() + 1)).slice(-2); 
							const day = ('0' + date.getDate()).slice(-2);
							return `${month}/${day}/${year}`
						}
						
						const UC = this;
						
						var events = JSON.parse(this.events)
						var holidayEvents = JSON.parse(this.holidayEvents)
						
						var eventGroups = JSON.parse(this.groups)
						var leavetypes = JSON.parse(this.leavetypes)
						var now = moment().minutes(0).seconds(0).milliseconds(0);
						var groupCount = 3;
						var itemCount = 20;
						
						// create a data set with groups
						var groups = new vis.DataSet();

						for (var i = 0; i < eventGroups.length; i++) {
							var eventGroup = eventGroups[i]
							groups.add(eventGroup)
						}
					
						events = events.concat(holidayEvents)
				
						// create a dataset with items
						var items = new vis.DataSet();
						for (var i = 0; i < events.length; i++) {
							var event = events[i]
							items.add(event)	
						}
						
						// create visualization
						var container = document.getElementById('visualization');
						var options = {
							groupOrder: 'content',  // groupOrder can be a property name or a sorting function
							orientation: {
								axis: 'both'
							},
							timeAxis: {
								scale: 'day',
								step: 1
							},
							showWeekScale: true,
							start: this.startDate,
							end: this.stopDate,
							zoomable:true,
							verticalScroll: true,
							horizontalScroll: true,
							zoomKey: 'ctrlKey',
							format: {
								minorLabels: {day: 'ddd DD'},
								//majorLabels: {day: 'w'}
				    		},
							maxHeight: '100%',
						};
						
						var winHeight = $(window).height();
						var timelineHeight = $('#visualization').height()
						
						console.log(winHeight + ' - ' + timelineHeight)
						
						var timeline = new vis.Timeline(container);
						timeline.setOptions(options);
						timeline.setGroups(groups);
						timeline.setItems(items);
						
						timeline.on('rangechange', function (properties) {
							styleEvents()
						});
						
						timeline.on('click', function (properties) {
							console.log(properties.item);
							console.log(timeline.itemSet.items)
							UC.item = properties.item
							UC.Click()
							let scrollTop = window.scrollY;
							console.log(scrollTop)
						});
						
						timeline.on('rangechanged', function (properties) {
							console.log('range changed')
							UC.newStartDate = formatDate(properties.start)
							UC.newStopDate = formatDate(properties.end)
							var newItems = new vis.DataSet();
							//timeline.setItems(newItems)
							UC.RangeChangedFromUC = true
						});
						
						function styleEventBG(className, color){
							var elements = document.getElementsByClassName(className)
							for (let i=0; i < elements.length; i++) {
								var element = elements[i]
								element.style.background = color
							}
						}
						function styleEvents(){
							for (var i = 0; i < events.length; i++) {
								var event = events[i]
								styleEventBG(`${event.id}`, event.color)
								styleEventBG(event.className, event.color)
							}
						}
						
						var keyDiv = document.getElementById('key')
						
						for (var i=0; i < leavetypes.length; i++) {
							var type = leavetypes[i]
							var element = document.createElement('div')
							element.innerHTML = `
							<div style="display:flex;">
							<div style="background: ${type.LeaveTypeColorApproved}; height:10px; width:10px; margin: 4px; margin-left: 10px"></div> <label>${type.LeaveTypeName}</label>
							</div>
							`
							keyDiv.appendChild(element);
						}
						
						
						styleEvents();
						
						var winHeight = $(window).height();			
						const visDiv = document.getElementById('visualization');
						
				        // Callback function to execute when the div's size changes
				        function onResize(entries) {
				            for (let entry of entries) {
				                if (entry.contentRect.height > winHeight-250) {
									$('#visualization').css("height", winHeight-250)
									$('#visualization').css("overflow", 'auto')
								}
								
				            }
				        }
						
				        // Create a new ResizeObserver instance
				        const resizeObserver = new ResizeObserver(onResize);
						resizeObserver.observe(visDiv);
						
						
						function wrapHolidayText() {
							const elements = document.querySelectorAll('.vis-item-content');
							elements.forEach(el => {
								el.style.textWrap = 'auto';
							});
						}
					
						wrapHolidayText()
						
					}catch(e){
						console.error(e)
					}
				
		}
		this.SetItems = function(events ) {

					this.events = events
					console.log(this.events)
					var events = JSON.parse(this.events)
					var items = new vis.DataSet();
					for (var i = 0; i < events.length; i++) {
						var event = events[i]
						console.log(event)
						items.add(event)
					}
				
		}
		this.Refresh = function(events ,groups ) {

					this.events = events
					this.groups = groups
					this.show()
				
		}


		this.onClickHandler = function (e) {
			if (e) {
				var target = e.currentTarget;
				e.preventDefault();
				 
				 
				 
				 
				 
				 
				 
				 
				 
				 
				 
				 
			}

			if (this.Click) {
				this.Click();
			}
		} 

		this.onclick2Handler = function (e) {
			if (e) {
				var target = e.currentTarget;
				e.preventDefault();
				 
				 
				 
				 
				 
				 
				 
				 
				 
				 
				 
				 
			}

			if (this.click2) {
				this.click2();
			}
		} 

		this.onDateRangeChangedHandler = function (e) {
			if (e) {
				var target = e.currentTarget;
				e.preventDefault();
				 
				 
				 
				 
				 
				 
				 
				 
				 
				 
				 
				 
			}

			if (this.DateRangeChanged) {
				this.DateRangeChanged();
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