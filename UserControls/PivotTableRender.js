function PivotTable($) {
	 this.setSDTProjects = function(value) {
			this.SDTProjects = value;
		}

		this.getSDTProjects = function() {
			return this.SDTProjects;
		} 
	  
	 this.setSDTEmployeeProjectHoursCollection = function(value) {
			this.SDTEmployeeProjectHoursCollection = value;
		}

		this.getSDTEmployeeProjectHoursCollection = function() {
			return this.SDTEmployeeProjectHoursCollection;
		} 
	  
	 this.setProjectHours = function(value) {
			this.ProjectHours = value;
		}

		this.getProjectHours = function() {
			return this.ProjectHours;
		} 
	  
	  
	  
	  
	  

	var template = '<style>	/* Freeze the last 3 columns */	td:nth-last-child(1), th:nth-last-child(1),	td:nth-last-child(2), th:nth-last-child(2),	td:nth-last-child(3), th:nth-last-child(3) {		position: sticky;		right: 0;		background-color: white; /* Adjust as needed */		/* z-index: 2; */		min-width:60px;	}	td:nth-last-child(1), th:nth-last-child(1) {		right: 0px; /* Adjust width according to column width */		margin-right:10px;	}	td:nth-last-child(2), th:nth-last-child(2) {		right: 60px; /* Adjust width according to column width */	}		td:nth-last-child(3), th:nth-last-child(3) {		right: 120px; /* Adjust width according to column width */	}</style><div id=\"print\" style=\"overflow:scroll; scrollbar-width:none; border: 1px solid #dddddd; margin-right:-3px;\">	<table class=\"my-sticky-column-table\">		<thead  style=\"position:sticky; top:0; z-index:0\">			<tr>				<th class=\'text-center\' style=\"position:sticky;left:0; background:white;\">Projects per employee:</th>				{{#SDTProjects}}				<th style=\"padding: 5px; background:#f5f5f5;\" scope=\"col\" class=\"text-center\"><a id=\'Project-{{Id}}\' style=\'cursor:pointer\' class=\'project\' >{{ProjectName}}</a></th>				{{/SDTProjects}}				{{#ShowLeaveTotal}}<th style=\"padding:5px; background:#f5f5f5;\" class=\"leave text-center\">Total Leave Hours</th><th style=\"padding:5px; background:#f5f5f5;\" class=\"leave text-center\">Total</th>{{/ShowLeaveTotal}}				<th style=\"background:#f5f5f5;\" class=\"work text-center\">Total Work Hours</th>			</tr>		</thead>						<tbody style=\'max-height:100px\'>			{{#SDTEmployeeProjectHoursCollection}}			<tr class=\"GridWithPaginationBar GridNoBorder WorkWithOdd text-center\">					<td style=\"font-weight: bold;background:#f5f5f5; position:sticky; left:0; z-index:1\" class=\'text-center\'><a href=\'\'  data-event=\"Click\" >{{EmployeeName}}</a></td>								{{#SDTProjects}}				<td id=\'{{EmployeeId}}-{{Id}}\' class=\"text-center\"></td>				{{/SDTProjects}}								<td class=\"work text-center\" style=\"font-weight: bold;background:#f5f5f5;\'>					<span class=\"tag\" style=\"padding: 0.5rem; {{#IsWorkTimeOptimal}} background:#00a95c; color:white; border-radius:5px;{{/IsWorkTimeOptimal}}\">{{TotalFormattedTime}}</span>				</td>				{{#ShowLeaveTotal}}<td class=\"leave text-center\" style=\"font-weight: bold; background:#f5f5f5;\">{{TotalFormattedLeave}}</td>{{/ShowLeaveTotal}}				{{#ShowLeaveTotal}}<td class=\'leave\' style=\"font-weight: bold; background:#f5f5f5;\">{{FormattedTotal}}</td>{{/ShowLeaveTotal}}							</tr>			{{/SDTEmployeeProjectHoursCollection}}					</tbody>				<tfoot>			<tr class=\"GridWithPaginationBar GridNoBorder WorkWithOdd\">				<td style=\"font-weight: bold;background:#fff; position:sticky; left:0; z-index:1\">Total</td>				{{#SDTProjects}}				<td class=\"project-total text-center\" id=\'{{Id}}\' scope=\"col\">0</td>				{{/SDTProjects}}				<td id=\'totalWorkHours\' class=\"work text-center\" style=\'bold;background:#f5f5f5;\'>{{TotalFormattedWorkTime}}</td>				{{#ShowLeaveTotal}}<td class=\"leave text-center\" style=\'\'></td>{{/ShowLeaveTotal}}				{{#ShowLeaveTotal}}<td class=\"leave text-center\" style=\'\'>{{TotalFormattedTime}}</td>{{/ShowLeaveTotal}}							</tr>		<tfoot>			</table></div><script type=\"text/javascript\">    $(document).ready(function() {			$(window).on(\'resize\', function() {			// Your code here			var newHeight = $(window).height();			console.log(\"New height: \" + newHeight);			$(\'#print\').css(\"max-height\", newHeight-100)			// Perform actions based on the new height		});  });  </script>';
	var partials = {  }; 
	Mustache.parse(template);
	var _iOnClick = 0; 
	var _iOnProjectClicked = 0; 
	var $container;
	this.show = function() {
			$container = $(this.getContainerControl());

			// Raise before show scripts

			_iOnClick = 0; 
			_iOnProjectClicked = 0; 

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
				.find("[data-event='ProjectClicked']")
				.on('projectclicked', this.onProjectClickedHandler.closure(this))
				.each(function (i) {
					this.setAttribute("data-items-index", i + 1);
				}); 

			// Raise after show scripts
			this.Start(); 
	}

	this.Scripts = [];

		this.Start = function() {

					const UC = this;
					function formatMinutesToHHMM(minutes) {
						var hours = Math.floor(minutes / 60);
						var remainingMinutes = minutes % 60;
						// Adding leading zeros if necessary
						var formattedHours = hours < 10 ? '0' + hours : hours;
						var formattedMinutes = remainingMinutes < 10 ? '0' + remainingMinutes : remainingMinutes;	
						return formattedHours + ':' + formattedMinutes;
					}
				
					for (let i = 0; i < this.SDTEmployeeProjectHoursCollection.length; i++) {
						var employee = this.SDTEmployeeProjectHoursCollection[i]
						var employeeId = employee.EmployeeId
						var projects = employee.ProjectHours
						
						
						if (projects) {
							for (let j=0; j < projects.length; j++) {
								var project = projects[j]
								var cell = document.getElementById(`${employeeId}-${project.ProjectId}`)
								cell.innerHTML = project.ProjectFormattedTime
								var totalCell = document.getElementById(`${project.ProjectId}`)
								totalCell.innerHTML = parseInt(totalCell.innerHTML) + project.ProjectTime
							}
						}
					}
					var totalCells = document.getElementsByClassName('project-total')
					var totalWorkHours = 0
					for (let i=0; i<totalCells.length;i++) {
						var cell = totalCells[i]
						var projectTime = parseInt(cell.innerHTML)
						totalWorkHours += projectTime
						cell.innerHTML = formatMinutesToHHMM(projectTime)
						document.getElementById('totalWorkHours').innerHTML = formatMinutesToHHMM(totalWorkHours)
						this.TotalFormattedWorkTime = formatMinutesToHHMM(totalWorkHours)
					}
					this.toggleLeave()
					
					var elements = document.getElementsByClassName('project')
					for (let i=0; i < elements.length; i++) {
						var element = elements[i]
						element.onclick = (event) => {
							var projectId = parseInt(event.target.id.replace('Project-',''))
							UC.CurrentProject = projectId
							UC.ProjectClicked()
						}
					}
				
					if (this.ShowLeaveTotal=='false'){
						console.log(this.ShowLeaveTotal)
					}
				
					var newHeight = $(window).height();
					$('#print').css("max-height", newHeight-100)
				
		}
		this.Refresh = function(SDTProjects ,SDTEmployeeProjectHoursCollection ) {

					this.SDTProjects = SDTProjects
					this.SDTEmployeeProjectHoursCollection = SDTEmployeeProjectHoursCollection
					this.show()
					this.TotalFormattedWorkTime = this.TotalFormattedWorkTime
				
		}
		this.GetLS = function() {

					return window.localStorage.get('Hello')
				
		}
		this.toggleLeave = function() {

					var elements = document.getElementsByClassName("leave");
					var workElements = document.getElementsByClassName("work");
					
					
					for (var i = 0; i < elements.length; i++) {
						
						if (this.ShowLeaveTotal=='true') {
							elements[i].classList.remove("hidden");
							} else {
							elements[i].classList.add("hidden");
						}
					}
				
					for (var i = 0; i < workElements.length; i++) {
						
						if (this.ShowLeaveTotal=='true') {
							workElements[i].style.right = 100
						} else {
							workElements[i].style.right = 0
						}
					}
				
		}


		this.onClickHandler = function (e) {
			if (e) {
				var target = e.currentTarget;
				e.preventDefault();
				 this.SDTProjectsCurrentIndex = (parseInt($(target).attr('data-items-index'), 10) || 1);  
				 
				 this.SDTEmployeeProjectHoursCollectionCurrentIndex = (parseInt($(target).attr('data-items-index'), 10) || 1);  
				 
				 this.ProjectHoursCurrentIndex = (parseInt($(target).attr('data-items-index'), 10) || 1);  
				 
				 
				 
				 
				 
			}

			if (this.Click) {
				this.Click();
			}
		} 

		this.onProjectClickedHandler = function (e) {
			if (e) {
				var target = e.currentTarget;
				e.preventDefault();
				 this.SDTProjectsCurrentIndex = (parseInt($(target).attr('data-items-index'), 10) || 1);  
				 
				 this.SDTEmployeeProjectHoursCollectionCurrentIndex = (parseInt($(target).attr('data-items-index'), 10) || 1);  
				 
				 this.ProjectHoursCurrentIndex = (parseInt($(target).attr('data-items-index'), 10) || 1);  
				 
				 
				 
				 
				 
			}

			if (this.ProjectClicked) {
				this.ProjectClicked();
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